### Waters


Write a C# app using Visual Studio that would help in playing word games. The application should include a UI that allows users to type in letters and then display the count and the list of English words that can be made from those letters by referencing the supplied word list. An installer program is not required, it is sufficient to be able to run from with Visual Studio.

Example
User types in:

THE

Program displays: 7

Each letter may not be used more than the number of times it appears in the entered letters. For instance, if ID is entered the program should not find DID, but if DID is entered then DID is clearly permissible.

<hr>

When I enter THE on your version the program displays 56043.

The program should list the words that can be made only from the letters entered but in any order.

For THE, the words listed should be:
EH
ET
ETH
HE
HET
TE
THE

There are other combinations of letters, such as HTE that you mention below – but they are not words that appear in the word list.

For DID, the words listed should be:
DI
DID
ID

This time you may use D up to two times because it appears twice in the input letters.

<hr>
