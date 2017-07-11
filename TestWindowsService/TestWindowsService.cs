using System.ServiceProcess;

namespace TestWindowsService
{
    public partial class TestWindowsService : ServiceBase
    {
        private readonly Worker worker = new Worker();

        public TestWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            worker.Start();
        }
      
        protected override void OnStop()
        {
            worker.Dispose();
            base.OnStop();
        }
    }
}