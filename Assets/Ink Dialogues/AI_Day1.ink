->main

=== main ===
Hi! My name is AI.
Nice to meet you.
Would you like to talk with me?
        +   [Yes]
            -> chosen("Yes")
        +   [No]
            -> chosen("No")
=== chosen(decision) ===
You chose {decision}!
Complete your daily game playing task next.
-> END
            