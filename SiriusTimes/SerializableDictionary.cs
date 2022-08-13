using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SiriusTimes
{
	[XmlRoot("Dictionary")]
	[Serializable]
	public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
	{
		public class Item
		{
			public TKey Key { get; set; }
			public TValue Value { get; set; }
		}

		public void Serialize(string filePath)
		{
			List<Item> itemList = new List<Item>();
			foreach (TKey key in this.Keys)
			{
				itemList.Add(new Item() { Key = key, Value = this[key] });
			}

			XmlSerializer serializer = new XmlSerializer(typeof(List<Item>));

			using (FileStream outputStream = new FileStream(filePath, FileMode.Create))
			{
				serializer.Serialize(outputStream, itemList);
			}
		}

		public bool Deserialize(string filePath)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Item>));
			List<Item> itemList = new List<Item>();

			if (File.Exists(filePath))
			{
				using (FileStream inputStream = new FileStream(filePath, FileMode.Open))
				{
					if (inputStream.Length == 0)
					{
						return false;
					}
					itemList = (List<Item>)serializer.Deserialize(inputStream);
				}
				foreach (Item item in itemList)
				{
					this.Add(item.Key, item.Value);
				}
			}
			else
			{
				return false;
			}
			return true;
		}
	}
}
