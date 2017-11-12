# RomanNumerals

The code consists of 5 libraries:

1. NumeralConversion - a library that exposes an arabic to roman numeral convertor which can be used in several parts of the application as requested

2. NumeralConversion.Tests - a library containing unit tests for the numeral conversion functionality

3. TextManipulation - a library that exposes an integer substitution service which will substitute all integers matched by the injected pattern with the result provided by the injected convertor

4. TextManipulation.Tests - a library containing unit tests for the text manipulation functionality

5. IntegrationTests - a library containing unit tests for the integrated functionality between a substitution service and a numeral convertor

Notes:

0. Build instructions
 
 Clone the repository or open it from the ZIP file, open in VS and build. The solution has some nuget packages installed, so for the first build it is required to have internet connection.

1. Extensibility
 
 The requirements do not mention anything about the code having to be extensible. I assumed that in a large application that performs complex text manipulations, more similar functionality may be needed later. Therefore, the code has been created to be easily extended at need.

2. Thread-safety
 
 It has not been requested, but the code is thread-safe.

3. Error handling

 - For Task 1, the convertor will throw an exception if the integer is not in the supported range. The exception should be handled by the caller code.

 - For Task 2, the substitution service will throw an exception if the conversion of a match fails. I have considered that if at least one match substitution fails, the whole process will be terminated and an exception will be thrown, containing the initial error as the inner exception.

 - No error logging has been created.

4. Performance

 - The requirements do not mention how big can the input text be for Task 2. I have created unit tests which substitute numerals in large strings having approx 200000000 characters. This takes about 14 seconds. Since no time limit was imposed I considered this to be fine. 

 - It is also not stated what is the probability that in a very large text, the same numeral will appear for a big numer of times. The current implementation will convert every match it finds regardless if it has seen it before in the same string. Again, I considered this ok. If better performance would have been required I would have gone with a caching mechanism.

5. Numerals

 - I am matching the integers from range 1-3999 with a regex. The regex will match any integer in this range that is surrounded by a word boundary. It will not match any integer that has a - in front (-6) or that is part of a word (abc4). It will match any integer from the specified range that has any other charactes surrounding it except for letters.

 - Since the arabic numerals do not contain spaces between their digits, but the roman numerals do, the next specific case may occur: the string "75 2" will become "LXX V II". Because there are no extra spaces inserted, it might be confusing when reading the resulting text. This was not specified in the requirements so I left it as it is.