using MSM.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSM.Socketing
{
    public class Server
    {
        private volatile TcpListener serverSocket;
        private volatile Socket clientSocket;

        public Thread Worker { get; set; }

        private bool _IsConnected;
        public bool IsConnected
        {
            get { return _IsConnected; }
        }

        private volatile bool _Closed;

        public bool Closed
        {
            get { return _Closed; }
            set { _Closed = value; }
        }


        // Singleton instance
        private static Server _Instance;
        public static Server Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Server();
                }
                return _Instance;
            }
        }

        /// <summary>
        /// Constructor, inicializa el hilo worker del servidor
        /// </summary>
        private Server()
        {
            Worker = new Thread(_InitServer);
            _IsConnected = false;
            _Closed = true;
        }

        /// <summary>
        /// Inicializa el servidor y espera a una conexión
        /// </summary>
        private void _InitServer()
        {
            _Closed = false;
            serverSocket = new TcpListener(GetLocalhostIP(), 52027);
            ConfigurationManager config = new ConfigurationManager();

            serverSocket.Start();
            Console.WriteLine("Esperando una conexion...");

            
            try {
                clientSocket = serverSocket.AcceptSocket();
            } catch (SocketException e)
            {
                // Este bloque try/catch debe existir en el caso de que 
                // se cierre la aplicacion sin haber ninguna conexion establecida
                // pues se corta la blocking call de AcceptSocket.

                // No es una mala práctica en esta situación pues no se está continuando el
                // la ejecución del programa recogiendo un error silenciosamente, sino para 
                // que no salten los errores excepcionales a la hora de CERRAR el programa.

                Console.WriteLine("Exiting gracefully");
            }

            // Comprobamos antes de continuar si hemos obtenido una conexión o
            // se ha atrapado la excepción que nos indica que se ha cerrado el listener
            // antes de establecer la conex -> Ergo se está cerrando la aplicación.

            if (clientSocket != null)
            {
                //clientSocket.ReceiveTimeout = (int)TimeSpan.FromMinutes(5.0).TotalMilliseconds;
                serverSocket.Stop();
                serverSocket = null;

                _IsConnected = true;

                Console.WriteLine("CONECTADO!!!!");

                try
                {
                    while (clientSocket.Connected && !Closed)
                    {
                        byte[] b = new byte[100];
                        int mensajeRecibido = clientSocket.Receive(b);

                        // Si la longitud del bufer (mensaje recibido) no es 0 significa que se
                        //recibió algo
                        if (mensajeRecibido != 0)
                        {
                            Console.Write("MENSAJE RECIBIDO >>");
                            for (int i = 0; i < mensajeRecibido; i++)
                            {
                                char num = Convert.ToChar(b[i]);
                                config.GetKeyboardMacroById("M" + num.ToString()).ExecuteMacroKeystrokes();
                            }
                        } else
                        // En caso contrario ya no hay conexión, pues solo un socket sin conexión a otro par
                        // recibe un bufer con 0 longitud (mensaje = 0).
                        {
                            if (!Closed)
                            {
                                Console.WriteLine("Changing IsConnected to false");
                                clientSocket.Close();

                                _IsConnected = false;

                                _InitServer();
                            }
                        }

                        

                    }
                }
                catch (SocketException)
                {
                    // Este trozo de código debe ser analizado/testeado para su eliminación

                    if (!Closed)
                    {
                        Console.WriteLine("Changing IsConnected to false");
                        clientSocket.Close();

                        _IsConnected = false;

                        _InitServer();
                    }                   

                }
            }
            
        }

        /// <summary>
        /// Inicializa el servidor poniendolo a la espera de una conexión.
        /// </summary>
        public void Init()
        {
            Worker.Start();
        }

        /// <summary>
        /// Cierra el servidor.
        /// </summary>
        public void Close()
        {
            if (!Closed)
            {
                _Closed = true;

                if (serverSocket != null)
                {
                    serverSocket.Stop();
                } else
                {
                    clientSocket.Close();
                }

                
            }
        }

        #region Net Utils Method

        /// <summary>
        /// Busca la dirección IP de la máquina en la que se ejecuta la aplicación
        /// </summary>
        /// <returns>IP de la máquina actual, localhost.</returns>
        public IPAddress GetLocalhostIP()
        {
            IPAddress localIP = null;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip;            
                }
            }

            return localIP;
        }

        #endregion
    }
}
