using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    //public delegate int WorkPerformedHandler(object sender, WorkedPerformedEventArgs e);

    class Worker
    {
        public event EventHandler<WorkedPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //if (WorkPerformed != null)
            //{
            //    WorkPerformed(hours, workType);
            //}

            var del = WorkPerformed as EventHandler<WorkedPerformedEventArgs>;
            if(del != null)
            {
                del(this, new WorkedPerformedEventArgs(hours, workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            //if (WorkCompleted != null)
            //{
            //    WorkCompleted(this, EventArgs.Empty);
            //}

            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}
