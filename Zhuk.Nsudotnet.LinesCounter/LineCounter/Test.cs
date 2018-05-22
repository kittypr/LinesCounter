namespace LineCounter
{
    public class Test
    {
        // comment
        private int a = 5;

        void TestMethod()
        {
            // comment
            
            // comment
            a = 6; 
            /*simple 
            multi
            line
            comment 
            */
            a = 7; /* tricky 
            multi /* 
            line
            //comment  
            */ a = 8;
            a = 8; /* comment */ a = 9; /* start
            multi
            end */
        }
    }
}
// sdfsdf
/* sdfasdf
*/