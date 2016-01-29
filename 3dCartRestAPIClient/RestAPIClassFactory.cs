using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace DCartRestAPIClient
{
    public interface IRestAPIType
    {

    }

    public class RestAPIClassFactory
    {
        /// <summary>
        /// Hashtable contains the mapping of class objects
        /// and string
        /// </summary>
        private Hashtable m_RestAPIClassMapping = new Hashtable();

        /// <summary>
        /// Single instance
        /// </summary>
        private static RestAPIClassFactory m_RestAPIClassTypes;

        /// <summary>
        /// Not to allow to create the instance of the
        /// class. Initialization will be done at very
        /// first time when the instance will be created
        /// </summary>
        public RestAPIClassFactory()
        {
            Initialize();
        }

        /// <summary>
        /// Implementation of singleton pattern
        /// </summary>
        internal static RestAPIClassFactory Singleton
        {
            get
            {
                if (m_RestAPIClassTypes == null)
                {
                    m_RestAPIClassTypes = new RestAPIClassFactory();
                }

                return m_RestAPIClassTypes;
            }
        }


        /// <summary>
        /// Intialize to perform the mapping of id and
        /// class name
        /// </summary>
        internal void Initialize()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            Type[] allTypes = asm.GetTypes();

            foreach (Type type in allTypes)
            {
                if (type.IsClass && !type.IsInterface)
                {
                    Type iRestAPIClass = type.GetInterface("IRestAPIType");
                    
                    if (iRestAPIClass != null)
                    {
                        RestAPIType restAPIType = (RestAPIType)type.GetProperty("key", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);

                        //if (restAPIType != null)
                        {
                            m_RestAPIClassMapping[restAPIType] = type;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Create the instance of specific product
        /// using reflection
        /// </summary>
        /// <param name="restAPIType"></param>
        /// <returns></returns>
        public IRestAPIType GetRestAPIClassType(RestAPIType restAPIType)
        {
            IRestAPIType restAPI = null;

            if (m_RestAPIClassMapping.ContainsKey(restAPIType))
            {
                Type apiType = (Type)m_RestAPIClassMapping[restAPIType];

                restAPI = Activator.CreateInstance(apiType) as IRestAPIType;
            }

            return restAPI;
        }


    }
}
