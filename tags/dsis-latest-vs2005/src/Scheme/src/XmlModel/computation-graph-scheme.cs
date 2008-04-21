﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:2.0.50727.1433
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.42.
// 
namespace DSIS.Scheme.XmlModel {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:shemas-dsis-org:computation-graph-xml")]
    [System.Xml.Serialization.XmlRootAttribute("Computation-Graph", Namespace="urn:shemas-dsis-org:computation-graph-xml", IsNullable=false)]
    public partial class ComputationScheme {
        
        private Action[] actionsField;
        
        private Connections connectionsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Code-Action", typeof(UserAction), IsNullable=false)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Xml-Action", typeof(XmlAction), IsNullable=false)]
        public Action[] Actions {
            get {
                return this.actionsField;
            }
            set {
                this.actionsField = value;
            }
        }
        
        /// <remarks/>
        public Connections Connections {
            get {
                return this.connectionsField;
            }
            set {
                this.connectionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:shemas-dsis-org:computation-graph-xml")]
    public partial class UserAction : Action {
        
        private string classField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Class {
            get {
                return this.classField;
            }
            set {
                this.classField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XmlAction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UserAction))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:shemas-dsis-org:computation-graph-xml")]
    public partial class Action : IdAttribute {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Action))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XmlAction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UserAction))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:shemas-dsis-org:computation-graph-xml")]
    public partial class IdAttribute {
        
        private string idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:shemas-dsis-org:computation-graph-xml")]
    public partial class Arc {
        
        private object itemField;
        
        private EdgePoint toField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("From-Action", typeof(EdgePoint))]
        [System.Xml.Serialization.XmlElementAttribute("From-Action-Instance", typeof(IdAttribute))]
        [System.Xml.Serialization.XmlElementAttribute("From-Object", typeof(System.Xml.XmlElement))]
        public object Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
        
        /// <remarks/>
        public EdgePoint To {
            get {
                return this.toField;
            }
            set {
                this.toField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:shemas-dsis-org:computation-graph-xml")]
    public partial class EdgePoint : PointAttribute {
        
        private string idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EdgePoint))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:shemas-dsis-org:computation-graph-xml")]
    public partial class PointAttribute {
        
        private string pointField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Point {
            get {
                return this.pointField;
            }
            set {
                this.pointField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:shemas-dsis-org:computation-graph-xml")]
    public partial class Connections {
        
        private Arc[] arcField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Arc")]
        public Arc[] Arc {
            get {
                return this.arcField;
            }
            set {
                this.arcField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:shemas-dsis-org:computation-graph-xml")]
    public partial class XmlAction : Action {
        
        private PointAttribute[] inputField;
        
        private PointAttribute[] outputField;
        
        private ComputationScheme[] valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Input")]
        public PointAttribute[] Input {
            get {
                return this.inputField;
            }
            set {
                this.inputField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Output")]
        public PointAttribute[] Output {
            get {
                return this.outputField;
            }
            set {
                this.outputField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Value")]
        public ComputationScheme[] Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
}