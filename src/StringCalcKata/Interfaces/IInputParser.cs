using StringCalcKata.Models;

namespace StringCalcKata.Interfaces
{
    public interface IInputParser
    {
        InputInfo Parse(string input);
    }
}
