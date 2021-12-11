# RockPaperScissor (Discord)
_Discord Bot_ made in C# that transform the classic old game in an __Epic TCG!__

![GameLogo](https://user-images.githubusercontent.com/91074795/138598988-4575d421-b12e-41a3-ae66-1d6a62e4df47.png)
***


## CURRENT TO DO LIST
- [x] Implement the Bases of Duel
- [ ] Implement the Duel Variations of Game and WinLoseConditions
- [ ] Create the another three focus alocation
- [ ] There is no logic in element when the card does not correspond to the chosen element. Advantage need to be re-write
- [ ] Solve problems with private and server assumptions (There is no conection of an player and a server)

## DECTECTED BUGS
- [x] When you make a trade which you dispense a card, the duel_deck won't remove it. It turns a ghost card!
- [x] It is possible to create a duel_deck with repeated card index
- [x] Is possible to change your duel_deck while the game is occurring

---
---

## To Contributors
It's necessary to have a Discord Token in their Develop Portal. After get it, you need to run the 'token_file_creator.py' archive in the directory that have all the codes.
After that, i belive you will run this application without problems


---
---

## Apresentation
This game is played with a set of _Cards_ called _Deck_. The cards are created in a random way, with different levels of power and distinct specialities.
However, there are three _Elements_ that compounds every cards:

- __🦾 Impact:__ How _Strong_ it is
- __🏹 Precision:__ How _Accurate_ it is
- __💮 Enchant:__ How _Magic_ it is

_Duels_ consists of a strategic combat of cards seeking for more Points of Victories than your opponent.

---
## Decks
The Deck of a Card Master contains the following data:
  * The Cards you have (The Limit of cards you can possess is 30 cards)
  * The amount of Money (You start the game with 50 ℳ ).
  * Two Blank Duel Decks that referes the Cards you what to use in a Duel

---

## Cards and Elements
As it was said, Cards are formed for three elements of equal poder. But, there is a dominance order within the Elements:
- _Impact_ have advantage over _Precision_
- _Precision_ have advantage over _Enchant_
- _Enchant_ have advantage over _Impact_

All the Elements possess something called Elemental Award, activated ever you win a Round (This and what you will read now will be explained later):
- __Impact:__ In the next round, you receives +2d3 in the Element you choose as a Attacker/Defender
- __Precision:__ In the next round: If you are the Attack Duelist, you may choose three cards instead of two to be your Attack Front. In you are the Defense, you may choose two cards to show (Like the Attacker does), creating a Second-Defense-Fase after the Second-Attack-Fase
- __Enchant:__ In the next round: Before the First-Attack-Fase, you can choose a index of card that the opponent will not be able to use in this round

Besides the element, the cards are classified in 1 to 5 _Stars_. How higher the level, more powerfull the card is. There are three cards of 0 Stars. They are free and ever deck start with five of then:

Card|Impact|Precision|Enchant
:---: | :---: | :---: | :---: 
Rock|1|0|0
Scissor|0|1|0
Paper|0|0|1

---

## Claiming Cards
After a certain amount of time (Currently 30 minutes), ever Card Master has the right to claim a new card to the system.
Having 33.3% percent of chance to gain the claimed card.

If you succeed in claimed the card, you can choose what focus you wanted it's to have: Impact, Precision or Enchant
Note that the card you will get not necessarily will follows the focus you choosed. That is a random TCG!
And finally, ever card you get that way will come with a Star value that represents its general power

### Star and EP
1d100|Stars|EP|Percent to get *
:---: | :---: | :---: | :---: 
1-50|★|3|16.66%
51-75|★★|5|8.33%
76-90|★★★|7|5%
91-98|★★★★|9|2.66%
99-100|★★★★★|11|0.66%
\* Considering the claim chance

### Focus Allocation
1d4|Type of Focus|Description
:---: | :---: | :---:
1|Mitigated Focus|Distribute equally the EP into the Elements
2|Regulated Focus|Allocate half of the EP into the two Elements besides focus and then put the rest in the Focus
3|Random Focus|Allocate the EP randomly
4|Reforced Focus|Put all the EP in the Focus of the Card

---

## Duels
The Standard Duel (3 Cards, Not equal Star, Without bet) follows the following procediment:
  * 1. The system raffle a Duelist to start in the Attack, while the another will be de Defense
  * 2. Makes the First-Attack-Fase
        * a. The Attack Duelist chooses an Element to be the Attacker (Impact, Precision, Enchant and Power [Sum of all elements])
        * b. The Attack Duelist chooses two Cards from its Duel Deck to be the Attack Front
  * 3. Makes the Defense-Fase
        * a. The Defense Duelist chooses an Element to be the Defender as the Attack Duelist did
        * b. The Defense Duelist chooses one Card from its Duel Deck to be the Defense Card
  * 4. Makes the Second-Attack-Fase
        * a. Finnaly, the Attack Duelist chooses one Card from its Attack Front to be definitive Attack Card 
  * 5. Makes the Resolution
        * a. Compare the Elements (In case of dominance, sums +3 in value of the Element. All the elements have dominance against Power [Except Power])
        * b. The Duelist with the higher value in the choosed Element, wins the round and receive 1 Point of Victory
        * c. The Duelist who wins the round receives the Elemental Award [Poder don't have Elemental Award]
  * 6. In the end, the Duelist with more Victory Points is the Winner of the Duel





## FUTURE TO DO LIST
- [ ] Events in which the participants do quest and receive tematic cards
- [ ] Maybe a market where you can buy cards from the system? idk, i think coins are a little useless
