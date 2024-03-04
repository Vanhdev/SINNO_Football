using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public partial class Document : Dictionary<string, object>
    {
        #region CLONE
        public Document Clone()
        {
            var doc = new Document();
            foreach (var p in this)
            {
                doc.Add(p.Key, p.Value);
            }
            return doc;
        }
        public Document Copy(Document src, params string[] names)
        {
            if (names.Length == 0)
            {
                names = src.Keys.ToArray();
            }
            foreach (var name in names)
            {
                if (this.ContainsKey(name) == false)
                {
                    object v = null;
                    src.TryGetValue(name, out v);
                    if (v != null)
                    {
                        base.Add(name, v);
                    }
                }
            }
            return this;
        }
        public Document Move(Document dst, params string[] names)
        {
            if (names.Length == 0)
            {
                names = Keys.ToArray();
            }
            foreach (var name in names)
            {
                var v = this.GetValueCore(name, true);
                dst.Push(name, v);
            }
            return dst;
        }
        public T ChangeType<T>() where T : Document, new()
        {
            var dst = new T();
            dst.Copy(this);

            return dst;
        }
        public T ToObject<T>()
        {
            return JObject.FromObject(this).ToObject<T>();
        }
        public static T Parse<T>(string text) where T : Document
        {
            return JObject.Parse(text).ToObject<T>();
        }
        public static Document Parse(string text)
        {
            return JObject.Parse(text).ToObject<Document>();
        }
        public static T FromObject<T>(object src) where T : Document
        {
            return JObject.FromObject(src).ToObject<T>();
        }
        public static Document FromObject(object src)
        {
            return JObject.FromObject(src).ToObject<Document>();
        }
        #endregion

        protected virtual object GetValueCore(string name, bool remove = false)
        {
            object value;
            if (base.TryGetValue(name, out value))
            {
                if (remove)
                {
                    base.Remove(name);
                }
            }
            return value;
        }
        public Document Set(string name, object value)
        {
            this.Add(name, value);
            return this;
        }
        public void Push(string name, object value)
        {
            if (value == null || value.Equals(string.Empty))
            {
                Remove(name);
                return;
            }

            if (base.ContainsKey(name))
            {
                base[name] = value;
            }
            else
            {
                base.Add(name, value);
            }
        }
        public object Pop(string name)
        {
            return GetValueCore(name, true);
        }
        public T Pop<T>(string name)
        {
            return (T)(GetValueCore(name, true) ?? default(T));
        }
        public T SelectContext<T>(string name, Action<T> callback) where T : new()
        {
            var v = GetValueCore(name, false);
            if (v == null)
            {
                v = new T();
                Push(name, v);
            }
            else if (v.GetType() != typeof(T))
            {
                var obj = v is string ? JObject.Parse((string)v) : JObject.FromObject(v);
                v = obj.ToObject<T>();
                Push(name, v);
            }

            var context = (T)v;
            if (callback != null)
            {
                callback.Invoke(context);
            }
            return context;
        }
        public Document SelectContext(string name, Action<Document> callback)
        {
            var v = GetValueCore(name, false);
            if (v == null)
            {
                v = new Document();
                Push(name, v);
            }
            else if (!(v is Document))
            {
                var obj = v is string ? JObject.Parse((string)v) : JObject.FromObject(v);
                v = obj.ToObject<Document>();
                Push(name, v);
            }

            var context = (Document)v;
            if (callback != null)
            {
                callback.Invoke(context);
            }
            return context;
        }

        public override string ToString()
        {
            return JObject.FromObject(this).ToString();
        }

        #region GET ITEMS VALUES
        public T GetObject<T>(string name)
        {
            object v;
            if (!TryGetValue(name, out v))
            {
                return default(T);
            }
            if (typeof(T) == v.GetType())
            {
                return (T)v;
            }

            var obj = (v is string ? JObject.Parse((string)v) : JObject.FromObject(v)).ToObject<T>();
            return obj;
        }
        public T GetDocument<T>(string name) where T : Document, new()
        {
            var doc = GetObject<T>(name);
            if (doc == null)
            {
                doc = new T();
            }
            return doc;
        }
        public Document GetDocument(string name)
        {
            object v;
            if (!TryGetValue(name, out v))
            {
                return null;
            }
            if (v is Document)
            {
                return (Document)v;
            }
            return Parse(v.ToString());
        }
        public T GetArray<T>(string name)
        {
            object v;
            if (!TryGetValue(name, out v))
            {
                return default(T);
            }

            if (v.GetType() == typeof(T)) { return (T)v; }

            var obj = v is string ? JArray.Parse((string)v) : JArray.FromObject(v);
            return obj.ToObject<T>();
        }
        public T GetValue<T>(string name, T defaultValue)
        {
            object v;
            if (TryGetValue(name, out v))
            {
                try
                {
                    return (T)v;
                }
                catch
                {
                    return (T)Convert.ChangeType(v.ToString(), typeof(T));
                }
            }
            return defaultValue;
        }
        public T GetValue<T>(string name)
        {
            return GetValue<T>(name, default(T));
        }
        public DateTime? GetDateTime(string name)
        {
            var v = GetValueCore(name, false);
            if (v == null)
            {
                return null;
            }
            if (v is string)
            {
                return DateTime.Parse((string)v);
            }
            return (DateTime)v;
        }
        public string GetString(string name)
        {
            return this.GetValueCore(name, false)?.ToString();
        }

        public object SelectPath(string path)
        {
            var s = path.Split('.');
            object v = GetValueCore(s[0], false);

            if (s.Length < 2)
            {
                return v;
            }

            if (v != null) 
            {
                try
                {
                    Document doc = v is string ? Parse((string)v) : FromObject(v);
                    this[s[0]] = doc;

                    for (var i = 1; i < s.Length - 1; i++)
                    {
                        var k = s[i];
                        v = doc.GetValueCore(k, false);
                        if (v == null) { return null; }

                        doc[k] = v = FromObject(v);
                        doc = (Document)v;
                    }
                    return doc.GetValueCore(s[s.Length - 1], false);
                }
                catch
                {
                }
            }
            return null;
        }
        #endregion

        #region SET ITEMS VALUES
        public void SetObject(string name, object value)
        {
            Push(name, JObject.FromObject(value).ToString());
        }
        public void SetDocument(Document doc)
        {
            string name = (string)doc.Pop("_id");
            Push(name, doc);
        }
        public void SetArray(string name, object value)
        {
            Push(name, JArray.FromObject(value).ToString());
        }
        public virtual void SetString(string name, string value) => Push(name, value);
        #endregion

        #region ObjectId
        public string ObjectId { get => GetString("_id"); set => Push("_id", value); }
        public virtual string GetPrimaryKey(Document context)
        {
            return new BsonData.ObjectId();
        }

        public string Join(string seperator, params string[] names)
        {
            string s = string.Empty;
            foreach (string name in names)
            {
                object v;
                if (this.TryGetValue(name, out v))
                {
                    if (s.Length > 0) { s += seperator; }
                    s += v.ToString();
                }
            }
            return s;
        }
        public string Unique(params string[] names)
        {
            return this.Join("_", names);
        }
        #endregion
    }
}
