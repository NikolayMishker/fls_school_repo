using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using TreasureHunt.Map.VectorModels;

namespace TreasureHunt.Map.Serilization
{
    public class TreasureMapReader
    {
        private readonly Regex elementMatch = new Regex(@"^\s*(?<name>[\w]+)\s*\(\s*(?<par1>\d+)(?:\s*(?<sepN>[^\d\s]+)\s*(?<parN>\d+)\s*)*\s*\)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private readonly Stream sourceStream;

        public TreasureMapReader(Stream stream)
        {
            sourceStream = stream;
        }

        public TreasureMap ReadMap(ITreasureMapElementsFactory elementsFactory)
        {
            var tresureMap = new TreasureMap();
            using (var streamReader = new StreamReader(sourceStream, Encoding.UTF8, true, 1024, true))
            {
                do 
                {
                    var line = streamReader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    var elementInfo = Tokenize(line);

                    if (elementInfo == null)
                    {
                        ThrowParseExeption(line);
                    }

                    var element = elementsFactory.CreateMapElement(elementInfo);

                    if (element != null)
                    {
                        tresureMap.AddElement(element);
                    }
                    else 
                    {
                        ThrowParseExeption(line);
                    }
                    
                } while (true);

            }

            return tresureMap;
        }

        private TreasureMapElementInfo Tokenize(string rawElementInfo)
        {
            var matches = elementMatch.Matches(rawElementInfo);
            if (matches.Count != 1)
            {
                return null;
            }

            var tokens = new List<string>();
            var groups = matches[0].Groups;
            var firstParameterGroup = groups["par1"];
            var separators = groups["sepN"].Captures;
            var parameters = groups["parN"].Captures;

            tokens.Add(firstParameterGroup.Value);

            var subsequentParametersCount = separators.Count;

            for (int i = 0; i < subsequentParametersCount; i++)
            {
                tokens.Add(separators[i].Value);
                tokens.Add(parameters[i].Value);
            }

            var elementInfo = new TreasureMapElementInfo
            {
                Name = groups["name"].Value.ToUpperInvariant(),
                Tokens = tokens.ToArray()
            };

           return elementInfo;
        }

        private void ThrowParseExeption(string line)
        {
            throw new FormatException($"Cannot parse element: {line}");
        }
    }
}
