﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1434
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.42.
// 
namespace DSIS.CellImageBuilders.PointMethod {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:shemas-dsis-org:point-method-settings")]
    [System.Xml.Serialization.XmlRootAttribute("PointMethod-Settings", Namespace="urn:shemas-dsis-org:point-method-settings", IsNullable=false)]
    public partial class XsdPointMethodSettings {
        
        private int[] pointsField;
        
        private double overlapField;
        
        private bool overlapFieldSpecified;
        
        private bool overlapedField;
        
        public XsdPointMethodSettings() {
            this.overlapedField = false;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Point", IsNullable=false)]
        public int[] Points {
            get {
                return this.pointsField;
            }
            set {
                this.pointsField = value;
            }
        }
        
        /// <remarks/>
        public double Overlap {
            get {
                return this.overlapField;
            }
            set {
                this.overlapField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OverlapSpecified {
            get {
                return this.overlapFieldSpecified;
            }
            set {
                this.overlapFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Overlaped {
            get {
                return this.overlapedField;
            }
            set {
                this.overlapedField = value;
            }
        }
    }
}
