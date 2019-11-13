using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using d7p4n4Namespace.Algebra.Class;
using d7p4n4Namespace.Final.Class;
using d7p4n4Namespace.Context.Class;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace d7p4n4Namespace.EFMethods.Class
{
    public class Ac4ySDSequenceEntityMethods : Ac4ySDSequenceAlgebra
    {
		public string baseName { get; set; }

        public Ac4ySDSequenceEntityMethods() { }

        public Ac4ySDSequenceEntityMethods(string newBaseName)
        {
            baseName = newBaseName;
        }
	
        public Ac4ySDSequence findFirstById(Int32 id)
        {
            Ac4ySDSequence a = null;

            using (var ctx = new AllContext(baseName))
            {
                var query = ctx.Ac4ySDSequences
                                .Where(ss => ss.id == id)
                                .FirstOrDefault<Ac4ySDSequence>();

                a = query;
            }
            return a;
        }
		
		public Ac4ySDSequence LoadXmlById(int id)
        {
			Ac4ySDSequence a = null;

            using (var ctx = new AllContext(baseName))
            {
                var query = ctx.Ac4ySDSequences
                                .Where(ss => ss.id == id)
                                .FirstOrDefault<Ac4ySDSequence>();

                a = query;
            }

            string xml = a.serialization;

            Ac4ySDSequence aResult = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Ac4ySDSequence));

            StringReader reader = new StringReader(xml);
            aResult = (Ac4ySDSequence)serializer.Deserialize(reader);
            reader.Close();

            return aResult;
        }
		
	public void addNew(Ac4ySDSequence _Ac4ySDSequence)
	{
		using (var ctx = new AllContext(baseName))
            {
                ctx.Ac4ySDSequences.Add(_Ac4ySDSequence);

                ctx.SaveChanges();
            }
	}
	
	    public void SaveWithXml(Ac4ySDSequence _Ac4ySDSequence)
        {
            string xml = "";

            XmlSerializer serializer = new XmlSerializer(typeof(Ac4ySDSequence));
            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter);

            serializer.Serialize(xmlWriter, _Ac4ySDSequence);

            xml = stringWriter.ToString();

            _Ac4ySDSequence.serialization = xml;

			using (var ctx = new AllContext(baseName))
            {
                ctx.Ac4ySDSequences.Add(_Ac4ySDSequence);

                ctx.SaveChanges();
            }
        }
    }
}
