using System;
using System.Runtime.Serialization;

namespace MorseLibrary
{
    [Serializable]
    public class IncorrectSymbException : Exception
    {
        public string ParamName { get; private set; }
        public object ActualValue { get; private set; }

        protected IncorrectSymbException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                ParamName = info.GetString("ParamName");
                ActualValue = info.GetString("ActualValue");
            }
        }

        public IncorrectSymbException(string paramname, object actualvalue, string message)
            : base(message)
        {
            ParamName = paramname;
            ActualValue = actualvalue;
        }

        public IncorrectSymbException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public IncorrectSymbException(string paramname, string message)
            : base(message)
        {
            ParamName = paramname;
        }

        public IncorrectSymbException(string paramname)
        {
            ParamName = paramname;
        }

        public IncorrectSymbException()
        {
        }

        public override String Message
        {
            get
            {
                var mes = base.Message;
                if (!string.IsNullOrWhiteSpace(ParamName))
                {
                    mes += string.Format(@"
Параметр: {0} ", ParamName + '\n');
                }
                if (ActualValue != null)
                {
                    mes += string.Format("Значение: {0}", ActualValue);
                }

                return mes;
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("ActualValue", ActualValue);
            info.AddValue("ParamName", ParamName);
        }
    }
}