using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace PvrConverter
{
    /// <summary>
    /// ArgumentParser class
    /// Intelligent handling of command line arguments based on Richard Lopes' (GriffonRL's)
    /// class at http://www.codeproject.com/Articles/3111/C-NET-Command-Line-Arguments-Parser
    /// Supports both linux-style and windows-style parameter arguments.
    /// </summary>
    public class ArgumentParser
    {
        // Variables
        private StringDictionary namedParameters;
        private ArrayList unnamedParameters;

        // Constructor
        public ArgumentParser(string[] Args)
        {
            namedParameters = new StringDictionary();
            unnamedParameters = new ArrayList();

            Regex Spliter = new Regex(@"^-{1,2}|^/|=|:",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);

            Regex Remover = new Regex(@"^['""]?(.*?)['""]?$",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);

            string Parameter = null;
            string[] Parts;

            // Valid parameters forms:
            // {-,/,--}param{ ,=,:}((",')value(",'))
            // Examples: 
            // -param1 value1 --param2 /param3:"Test-:-work" 
            //   /param4=happy -param5 '--=nice=--'
            foreach (string Txt in Args)
            {
                if (Txt.StartsWith("-") || Txt.StartsWith("/") || Parameter != null)
                {
                    // A named param (key & value) has been provided
                    // Look for new parameters (-,/ or --) and a
                    // possible enclosed value (=,:)
                    Parts = Spliter.Split(Txt, 3);

                    switch (Parts.Length)
                    {
                        // Found a value (for the last parameter 
                        // found (space separator))
                        case 1:
                            if (Parameter != null)
                            {
                                if (!namedParameters.ContainsKey(Parameter))
                                {
                                    Parts[0] =
                                        Remover.Replace(Parts[0], "$1");

                                    namedParameters.Add(Parameter, Parts[0]);
                                }
                                Parameter = null;
                            }
                            // else Error: no parameter waiting for a value (skipped)
                            break;

                        // Found just a parameter
                        case 2:
                            // The last parameter is still waiting. 
                            // With no value, set it to true.
                            if (Parameter != null)
                            {
                                if (!namedParameters.ContainsKey(Parameter))
                                    namedParameters.Add(Parameter, "true");
                            }
                            Parameter = Parts[1];
                            break;

                        // Parameter with enclosed value
                        case 3:
                            // The last parameter is still waiting. 
                            // With no value, set it to true.
                            if (Parameter != null)
                            {
                                if (!namedParameters.ContainsKey(Parameter))
                                    namedParameters.Add(Parameter, "true");
                            }

                            Parameter = Parts[1];

                            // Remove possible enclosing characters (",')
                            if (!namedParameters.ContainsKey(Parameter))
                            {
                                Parts[2] = Remover.Replace(Parts[2], "$1");
                                namedParameters.Add(Parameter, Parts[2]);
                            }

                            Parameter = null;
                            break;
                    }
                }
                else
                {
                    // We have an unnamed parameter
                    unnamedParameters.Add(Txt);
                }
            }
            // In case a parameter is still waiting
            if (Parameter != null)
            {
                if (!namedParameters.ContainsKey(Parameter))
                    namedParameters.Add(Parameter, "true");
            }
        }

        /// <summary>
        /// Retrieve a parameter value if it exists 
        /// (overriding C# indexer property)
        /// </summary>
        /// <param name="Param">The name of the parameter to get</param>
        /// <returns></returns>
        public string this[string Param]
        {
            get
            {
                return (namedParameters[Param]);
            }
        }

        /// <summary>
        /// Retrieve an unnamed parameter by index if it exists 
        /// (overriding C# indexer property)
        /// </summary>
        /// <param name="index">The index of the parameter to get</param>
        /// <returns></returns>
        public string this[int index]
        {
            get
            {
                return (index < unnamedParameters.Count) ? (string)unnamedParameters[index] : null;
            }
        }

        /// <summary>
        /// Retrieve a parameter value if it exists , otherwise the given value
        /// </summary>
        /// <param name="key">The key to retrieve</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>A parameter value or the given default value</returns>
        public string GetOrDefault(string key, string defaultValue)
        {
            if (!namedParameters.ContainsKey(key))
            {
                return defaultValue;
            }

            return namedParameters[key];
        }
    }
}