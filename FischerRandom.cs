using System;
using System.Text;


/*Fischerrandom is chess with all the back rank pieces all jumbled and scrambled and crazy like. 
 * The only three rules are that the king has to be between the rooks, the bishops must be on opposite colored squares, 
 * and the two sides have to be exactly symmetrically the same! Make the output something like "RBNNKRQB" indicating the white back rank. 
 * You dont need the black because it is just a mirror of white on the other side of the board. 
 * If you wanted to get real fancy you could associate each value with a picture of the corresponding piece and output a fancy piece array. 
 * *edit added rule about opposite colored bishops
 * 
 * 1. King between rooks
 * 2. Bishops on opposite colored squares
 * 3. Symmetric
 * 4. Same number of pieces
 */

public class FischerRandom
{
	public static void main()
	{
        StringBuilder sb;
        do
        {
            sb = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                sb.Append(piece_generator());
            }
        } while (!configuration_verification(sb.ToString()));

        Console.WriteLine(sb.ToString());

        
	}


    //Uses the random class to randomize an integer from 0 to 4
    public char piece_generator()
    {
        Random rnd = new Random();
        int result = rnd.Next();
        char piece = 'X';
        switch(result)
        {
            case 0:
                piece = 'Q';
                break;

            case 1:
                piece = 'R';
                break;

            case 2:
                piece = 'N';
                break;

            case 3:
                piece = 'B';
                break;

            case 4:
                piece = 'K';
                break;
        }
        return piece;
    }

    /*Uses helper methods to check whether:
     * 1. There is an appropriate amount of pieces on the back_row
     * 2. The King piece is between the Rook pieces
     * 3. The Bishop pieces are on opposite colors
     */
    public bool configuration_verification(String back_row)
    {
        bool verified = false;
        try
        {
            if(correct_amount_of_pieces(back_row) && 
                king_between_rooks(back_row) &&
                bishops_on_opposite_colors)
            {
                verified = true;
            }


            return verified;

        }
        catch (Exception e)
        {
            Console.WriteLine("Configuration error");
            throw;
        }
    }

    /*returns true if there are:
     * 2 of each: R, B, N
     * 1 of each: K, Q
     * in the string given to it.
     */
    private bool correct_amount_of_pieces(String back_row)
    {
        int rook_amount = 2, bishop_amount = 2, knight_amount = 2, king_amount = 1, queen_amount = 1;
        bool correct_amount = false;
        foreach (var piece in back_row)
        {
            switch (var)
            {
                case 'R':
                    rook_amount--;
                    break;

                case 'B':
                    bishop_amount--;
                    break;

                case 'N':
                    knight_amount--;
                    break;

                case 'K':
                    king_amount--;
                    break;

                case 'Q':
                    queen_amount--;
                    break;

                default:
                    break;
            }
        }

        if(rook_amount == 0 && bishop_amount == 0 && knight_amount == 0 && king_amount == 0 && queen_amount == 0)
        {
            correct_amount = true;
        }

        return correct_amount;
             
    }

    //returns true if the index of the King piece is between the indices of the Rook pieces
    private bool king_between_rooks(String back_row)
    {
        bool between = (back_row.IndexOf('R') < back_row.IndexOf('K') && back_row.IndexOf('K') < back_row.LastIndexOf('R'));
        return between;
    }

    //returns true if there is an odd difference between the bishop pieces, meaning that they are on different colors
    private bool bishops_on_opposite_colors(String back_row)
    {
        int difference_of_positions = back_row.LastIndexOf('B') - back_row.IndexOf('B');
        bool opposite = (difference_of_positions % 2 == 1);
        return opposite;
    }
}
