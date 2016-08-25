using MSM.Socketing;
using MSM.UI.Practices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSM.UI.ViewModels.PartialContent
{
    public class ControlConnectionViewModel : ViewModelBase
    {
        
        public BackgroundWorker bw;
        #region Propiedades

        public bool IsServerConnected
        {
            get { return _Server.IsConnected; }
        }

        public string LocalhostIP
        {
            get { return _Server.GetLocalhostIP().ToString(); }
        }

        private Server _Server;
        public Server Server
        {
            get { return _Server; }
        }


        #endregion

        #region Constructor

        public ControlConnectionViewModel()
        {
            _Server = Server.Instance;

            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += Heartbeat_ConnCheck;

            bw.RunWorkerAsync();
        }

        #endregion

        #region Backgroundworker Heartbeat

        private void Heartbeat_ConnCheck(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker b = sender as BackgroundWorker;
            while (!b.CancellationPending)
            {
                NotifyPropertyChanged("IsServerConnected");
                Thread.Sleep(50);
            }
        }

        #endregion
    }
}
