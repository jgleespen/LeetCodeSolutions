public class ValidAnagram {

  /*Finds if t is an anagram of S in O(s.Length + t.Length) time

*/
        public static bool IsAnagram(string s, string t)
        {
          //set strings to array structs
            char[] sa = s.ToCharArray(); 
            char[] ta = t.ToCharArray();
            if (s.Length != t.Length)
            {
                return false;

            }

            //map struct to store each character and its frequency in s
            Dictionary<char, int> sd = new Dictionary<char, int>();

            foreach (var c in sa)
            {
                //if c is in map, increment frequency
                if (sd.TryGetValue(c, out int value))
                {
                    sd[c] = value + 1;
                    Console.WriteLine("(k, v): " + sd[c]);
                }
                //add it if not found
                else
                {
                    sd.Add(c, 1);
                }

            }

            for (int i = 0; i < ta.Length; i++)
            {
                //decrement if map holds char in t
                if (sd.TryGetValue(ta[i], out int value))
                    sd[ta[i]] = value - 1;
                //if character doesnt exist in map return false
                else if (!sd.TryGetValue(ta[i], out int v2))
                    return false;

                else if (sd[ta[i]] < 0) return false;
            }

            return true;
        }
}
