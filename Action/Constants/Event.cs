using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action.Constants
{
    enum Event
    {
        MouseEV_Move = 0x0001, 		/* mouse move 			*/
        MouseEV_LeftDown = 0x0002, 	/* left button down 	*/
        MouseEV_LeftUp = 0x0004, 	/* left button up 		*/
        MouseEV_RightDown = 0x0008, 	/* right button down 	*/
        MouseEV_RightUp = 0x0010 	/* right button down 	*/

    }
}
