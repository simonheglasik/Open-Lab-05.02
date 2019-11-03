# Open-Lab-05.02
(18 XP) A function that removes useless marks from the end of a sentence.

1. Fork this repository to your GitHub account.
2. Open solution file in Visual Studio.
3. Open file `StringTools.cs`.
4. Implement the method `NoYelling(string sentence)` that transforms a sentence that ends with multiple question marks `?` or multiple exclamation marks `!` into a sentence that ends only with one.
5. Run with `CTRL+F5` to test it.
6. If all tests are passed, commit & sync your repository.
7. Send a link to your repository for Lab Master (in #slack) to check it.

## Examples: 
```C#
NoYelling("What went wrong?????????") ➞ "What went wrong?"

NoYelling("Oh my goodness!!!") ➞ "Oh my goodness!"

NoYelling("I just!!! can!!! not!!! believe!!! it!!!") ➞ "I just!!! can!!! not!!! believe!!! it!"
// Only change repeating punctuation at the end of the sentence.

NoYelling("Oh my goodness!") ➞ "Oh my goodness!"
// Don't change sentences where there is one question mark/exclamation mark at the end.

NoYelling("I just cannot believe it..") ➞ "I just cannot believe it.."
// Don't change sentences that don't end with question mark/exclamation mark.
```
