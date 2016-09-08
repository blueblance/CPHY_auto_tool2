using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPhyGenCtlRPC;

namespace CPHY_auto_tool
{
    public partial class PG_control
    {
        public static int PE(int rc)
        {
            if (rc < 0)
            {
                Console.WriteLine(string.Format("Error {0} occurred in command!", rc));
                Console.WriteLine(string.Format("   status msg: {0}", m_sMsg));
                Console.WriteLine(string.Format("   error msg: {0}", m_eMsg));
            }
            return (rc);
        }


        public static int RPCCmd<T1>(int cmdCode, T1 arg1)
        {
            return (PE(client.RPCCmd(cmdCode, arg1, ref m_eMsg, ref m_sMsg)));
        }

        public static int RPCCmd<T1, T2>(int cmdCode, T1 arg1, T2 arg2)
        {
            return (PE(client.RPCCmd(cmdCode, arg1, arg2, ref m_eMsg, ref m_sMsg)));
        }

        public static int RPCCmd<T1, T2, T3>(int cmdCode, T1 arg1, T2 arg2, T3 arg3)
        {
            return (PE(client.RPCCmd(cmdCode, arg1, arg2, arg3, ref m_eMsg, ref m_sMsg)));
        }
        public static int RPCCmd<T1, T2, T3, T4>(int cmdCode, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return (PE(client.RPCCmd(cmdCode, arg1, arg2, arg3, arg4, ref m_eMsg, ref m_sMsg)));
        }

        // Define RPCCmd shorthand (no arguments)
        public static int RPCCmd(int cmdCode)
        {
            return (PE(client.RPCCmd(cmdCode, ref m_eMsg, ref m_sMsg)));
        }
    }
}
