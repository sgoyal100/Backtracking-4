// Time Complexity : O(k^n)
// Space Complexity : O(n)
// Did this code successfully run on Leetcode : Noe, premium subscription problem
// Any problem you faced while coding this : No


// Your code here along with comments explaining your approach
List<string> expandResult;
public string[] Expand(string s)
{
    if (string.IsNullOrEmpty(s))
        return new string[] { };

    expandResult = new List<string>();
    List<List<char>> blocks = new List<List<char>>();

    int i = 0;
    //creates list of list chars, so that we know at which substring of curly brcaes or single char we are traversing            
    while(i < s.Length)
    {
        char c = s[i];
        var block = new List<char>();
        if (c == '{')
        {
            i++;
            while (s[i] != '}')
            {
                if (s[i] != ',')
                    block.Add(s[i]);
            }
            i++;
        }
        else
            block.Add(c);

        blocks.Add(block);
        i++;
    }
    backtrackingExpand(blocks, new StringBuilder(), 0);
    string[] answer = new string[expandResult.Count];
    for (int j = 0; j < expandResult.Count; j++)
    {
        answer[j] = expandResult[j];
    }
    //Array.Sort(answer);
    return answer;
}

private void backtrackingExpand(List<List<char>> blocks, StringBuilder sb, int index)
{
    //base
    if (index == blocks.Count)
        expandResult.Add(sb.ToString());

    //logic
    //get the current block and rin for loop based recursion
    List<char> block = blocks[index];
    for (int i = 0; i < block.Count; i++)
    {
        //add current character into string buidler
        //action
        sb.Append(block[i]);
        //recurse
        //do recursion for next index with current chracter added
        backtrackingExpand(blocks, sb, index + 1);
        //backtrack
        //removes the last character added in stringbuilder
        sb.Length = sb.Length - 1;
    }
}