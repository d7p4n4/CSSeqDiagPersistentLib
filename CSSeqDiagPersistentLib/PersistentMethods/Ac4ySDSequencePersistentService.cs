
using System;
using System.Collections.Generic;
using System.Linq;
using CSAc4yObjectService.Class;
using CSAc4yService.Class;
using d7p4n4Namespace.EFMethods.Class;
using d7p4n4Namespace.Final.Class;

namespace d7p4n4Namespace.PersistentService.Class
{
    public class Ac4ySDSequencePersistentService
    {
	
		public string baseName { get; set; }
		private Ac4ySDSequenceEntityMethods _Ac4ySDSequenceEntityMethods { get; set; }
		
		public Ac4ySDSequencePersistentService() { }

        public Ac4ySDSequencePersistentService(string newBaseName)
        {
            baseName = newBaseName;
            _Ac4ySDSequenceEntityMethods = new Ac4ySDSequenceEntityMethods(baseName);
        }

        public GetObjectResponse GetFirstById(int id)
        {
            var response = new GetObjectResponse();
            try
            {
                response.Object = (_Ac4ySDSequenceEntityMethods.findFirstById(id));
                response.Result = new Ac4yProcessResult() { Code = "1" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = "-1", Message = exception.StackTrace });
            }

            return response;
        }

        public GetObjectResponse GetFirstWithXML(int id)
        {
            var response = new GetObjectResponse();
            try
            {
                response.Object = (_Ac4ySDSequenceEntityMethods.LoadXmlById(id));
                response.Result = new Ac4yProcessResult() { Code = "1" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = "-1", Message = exception.StackTrace + "\nBaseName: " + _Ac4ySDSequenceEntityMethods.baseName});
            }

            return response;
		}
		
		public GetObjectResponse SaveWithXml(Ac4ySDSequence _Ac4ySDSequence)
        {
            var response = new GetObjectResponse();
            try
            {
                _Ac4ySDSequenceEntityMethods.SaveWithXml(_Ac4ySDSequence);
                response.Result = new Ac4yProcessResult() { Code = "1" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = "-1", Message = exception.StackTrace });
            }

            return response;
        }
		
		public GetObjectResponse Save(Ac4ySDSequence _Ac4ySDSequence)
        {
            var response = new GetObjectResponse();
            try
            {
                _Ac4ySDSequenceEntityMethods.addNew(_Ac4ySDSequence);
                response.Result = new Ac4yProcessResult() { Code = "1" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = "-1", Message = exception.StackTrace });
            }

            return response;
        }
    }
}
