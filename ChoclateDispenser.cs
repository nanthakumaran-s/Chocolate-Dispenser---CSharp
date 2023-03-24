using System;
using System.Linq;

public class ChoclateDispenser
{
    private List<string> chocolates = new List<string>();
    private Dictionary<string, int> countOfEachColor = new Dictionary<string, int>()
    {
        {"green", 0},
        {"silver", 0},
        {"blue", 0},
        {"crimson", 0},
        {"purple", 0},
        {"red", 0},
        {"pink", 0}
    };

    public void AddChocolates(string color, int count)
    {
        for (int i = 0; i < count; i++)
        {
            chocolates.Insert(0, color);
            countOfEachColor[color]++;
        }
    }

    public List<string> RemoveChocolates(int number)
    {
        List<string> removedChocolates = new List<string>();
        for (int i = 0; i < number && chocolates.Count > 0; i++)
        {
            removedChocolates.Add(chocolates[0]);
            countOfEachColor[chocolates[0]]--;
            chocolates.RemoveAt(0);
        }
        return removedChocolates;
    }

    public List<string> DispenseChocolates(int number)
    {
        List<string> dispensedChocolates = new List<string>();
        for (int i = 0; i < number && chocolates.Count > 0; i++)
        {
            dispensedChocolates.Add(chocolates[chocolates.Count - 1]);
            countOfEachColor[chocolates[chocolates.Count - 1]]--;
            chocolates.RemoveAt(chocolates.Count - 1);
        }
        return dispensedChocolates;
    }

    public List<string> DispenseChocolatesOfColor(int number, string color)
    {
        List<string> dispensedChocolates = new List<string>();
        for (int i = 0; i < number && chocolates.Count > 0; i++)
        {
            int index = chocolates.FindIndex(c => c.Contains(color));
            if (index == -1)
            {
                break;
            }
            dispensedChocolates.Add(chocolates[index]);
            countOfEachColor[chocolates[index]]--;
            chocolates.RemoveAt(index);
        }
        return dispensedChocolates;
    }

    public int[] NoOfChocolates()
    {
        int[] led = new int[] { 
            countOfEachColor["green"], 
            countOfEachColor["silver"], 
            countOfEachColor["blue"], 
            countOfEachColor["crimson"], 
            countOfEachColor["purple"], 
            countOfEachColor["red"], 
            countOfEachColor["pink"] 
        };
        return led;
    }

    public void SortChocolateBasedOnCount()
    {
        int n = chocolates.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (countOfEachColor[chocolates[j]] < countOfEachColor[chocolates[j + 1]])
                {
                    (chocolates[j], chocolates[j + 1]) = (chocolates[j + 1], chocolates[j]);
                }
            }
        }

    }

    public void ChangeChocolateColor(int number, string color, string finalColor)
    {
        int count = 0;
        for (int i = 0; i < chocolates.Count && count < number; i++)
        {
            if (chocolates[i] == color)
            {
                chocolates[i] = finalColor;
                countOfEachColor[color]--;
                countOfEachColor[finalColor]++;
                count++;
            }
        }
    }

    public object ChangeChocolateColorAllOfxCount(string color, string finalColor)
    {
        int count = countOfEachColor[color];
        countOfEachColor[finalColor] += count;
        countOfEachColor[color] = 0;
        for(int i = 0; i < chocolates.Count; i++)
        {
            if (chocolates[i] == color)
            {
                chocolates[i] = finalColor;
            }
        }
        List<object> result = new List<object>() { count, chocolates };
        return result;
    }

    public void RemoveChocolateOfColor(string color)
    {
        int index = chocolates.FindIndex(c => c.Contains(color));
        if (index != -1)
        {
            chocolates.RemoveAt(index);
        }
    }
}
