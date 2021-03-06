﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;
using Prism.Mvvm;

namespace Accord.DataModel
{

    public class NameRuleError : BindableBase
    {
        //public readonly NameRuleViolations Violation;


        private NameRuleViolations _violation;

        public NameRuleViolations Violation
        {
            get { return _violation; }
            set { _violation = value; }
        }

        //public readonly string Namespace;
        //public readonly string ClassName;
        //public readonly string Method;
        //public readonly string Parameter;

        private string nameSpaceName;

        public string NameSpace
        {
            get { return nameSpaceName; }
            set
            {
                nameSpaceName = value;
                RaisePropertyChanged(nameof(NameSpace));
            }
        }



        public string NameRuleViolationString
        {
            get { return Violation.ToString(); }
        }

        private string className;

        public string ClassName
        {
            get { return className; }
            set
            {
                className = value;
                RaisePropertyChanged(nameof(ClassName));
            }
        }

        private string methodName;

        public string Method
        {
            get { return methodName; }
            set { methodName = value; RaisePropertyChanged(nameof(Method)); }
        }

        private string _parameter;

        public string Parameter
        {
            get { return _parameter; }
            set
            {
                _parameter = value;
                RaisePropertyChanged(nameof(Parameter));
            }
        }

        private string _propOrField;

        public string PropOrField
        {
            get { return _propOrField; }
            set { _propOrField = value; RaisePropertyChanged(nameof(PropOrField)); }
        }


        public string Suggestion
        {
            get { return GetSuggestion(); }
        }


        public NameRuleError(NameRuleViolations violation, string nameSpace, string className, string method, string parameter, string propOrField)
        {
            Violation = violation;
            NameSpace = nameSpace;
            ClassName = className;
            Method = method;
            Parameter = parameter;
            PropOrField = propOrField;
        }

        public virtual string GetErrorMessage()
        {
            var result = string.Format("{0} at {1} {2} {3}", Violation.ToString(), NameSpace, ClassName, Method, Parameter);
            return result;
        }

        public virtual string GetSuggestion()
        {
            var desc = EnumDescriptionFetcher.GetDescription<NameRuleViolations>(Violation);
            return desc;
        }
    }
}
