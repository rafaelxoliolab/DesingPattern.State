using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPattern.State
{
    public static class Structural
    {
        public static void run()
        {
            Context context = new Context(new ConcreteStateA());
            context.Request();
            context.Request();
            context.Request();
            context.Request();
            context.Request();

            Console.ReadKey();
        }
    }

    /// <summary>
    /// Context class used by the clients.
    /// This class holds a concrete state object that provides the behavior according to its current state.
    /// </summary>
    class Context {

        private State state;

        public Context(State state)
        {
            this.state = state;
        }

        public State State
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        /// Method used to handle the state of the current Context
        /// </summary>
        public void Request()
        {
            state.Handle(this);
        }
    }

    /// <summary>
    /// Abstract class used by the Context object
    /// </summary>
    abstract class State
    {
        public abstract void Handle(Context context);
    }

    /// <summary>
    /// Concrete class that implement the State abstract class.
    /// </summary>
    class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("Handle State called from ConcreteStateA and passing to ConcreteStateB");
            context.State = new ConcreteStateB();
        }
    }

    /// <summary>
    /// Concrete class that implement the State abstract class.
    /// </summary>
    class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("Handle State called from ConcreteStateB and passing to ConcreteStateA");
            context.State = new ConcreteStateA();
        }
    }
}
