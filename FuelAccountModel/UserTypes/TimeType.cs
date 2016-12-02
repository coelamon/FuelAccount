using System;
using NHibernate.UserTypes;
using NHibernate.SqlTypes;

namespace FuelAccountModel.UserTypes
{
    class TimeType : IUserType
    {
        public bool IsMutable
        {
            get
            {
                return false;
            }
        }

        public Type ReturnedType
        {
            get
            {
                return typeof(TimeSpan);
            }
        }

        public SqlType[] SqlTypes
        {
            get
            {
                return new SqlType[] { new SqlType(System.Data.DbType.Time) };
            }
        }

        public object Assemble(object cached, object owner)
        {
            throw new NotImplementedException();
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Disassemble(object value)
        {
            throw new NotImplementedException();
        }

        public new bool Equals(object x, object y)
        {
            return ((TimeSpan)x).Equals(y);
        }

        public int GetHashCode(object x)
        {
            throw new NotImplementedException();
        }

        public object NullSafeGet(System.Data.IDataReader rs, string[] names, object owner)
        {
            return rs[names[0]];
        }

        public void NullSafeSet(System.Data.IDbCommand cmd, object value, int index)
        {
            ((System.Data.IDataParameter)(cmd.Parameters[index])).Value = value;
        }

        public object Replace(object original, object target, object owner)
        {
            throw new NotImplementedException();
        }
    }
}
