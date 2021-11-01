        public static Dictionary<string, int> Interpret(string[] program)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            var commands = program;


            for (int currentIndex = 0; currentIndex < commands.Length; currentIndex++)
            {
                var elem = commands[currentIndex].Split();


                if (elem[0] == "mov")
                {
                    if (!dict.ContainsKey(elem[1]))
                    {
                        if (!dict.ContainsKey(elem[2]))
                            dict.Add(elem[1], int.Parse(elem[2]));
                        else
                            dict.Add(elem[1], dict[elem[2]]);
                    }

                    else
                    {
                        if (!dict.ContainsKey(elem[2]))
                            dict[elem[1]] = int.Parse(elem[2]);
                        else
                            dict[elem[1]] = dict[elem[2]];
                    }
                }

                else if (elem[0] == "inc")
                    dict[elem[1]] += 1;

                else if (elem[0] == "dec")
                    dict[elem[1]] -= 1;

                else if (elem[0] == "jnz")
                {
                    int result;
                    if (int.TryParse(elem[1], out result))
                    {
                        if (result != 0)
                        {
                            if (!dict.ContainsKey(elem[2]) && int.Parse(elem[2]) != 0)
                                currentIndex += int.Parse(elem[2]) - 1;
                            else if (dict[elem[2]] != 0)
                                currentIndex += dict[elem[2]] - 1;
                        }
                    }

                    else
                    {
                        if (dict[elem[1]] != 0)
                        {
                            if (!dict.ContainsKey(elem[2]) && int.Parse(elem[2]) != 0)
                                currentIndex += int.Parse(elem[2]) - 1;
                            else if (dict[elem[2]] != 0)
                                currentIndex += dict[elem[2]] - 1;
                        }
                    }
                }
            }
            return dict;
        }
