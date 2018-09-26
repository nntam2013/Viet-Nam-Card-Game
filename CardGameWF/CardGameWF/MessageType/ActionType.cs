using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketProperties
{
    public enum ActionType
    {
        //Action type
        START_NEW_GAME_REQUEST,
        SET_FIRST_TURN_FLAG,


        //Route send and server receive
        CHECK_SERVER_CONNECTION,
        CHECK_CLIENT_CONNECTION,
        SET_ID_FOR_SOCKET,
        // DEAL_CARDS_FOR_PLAYERS,//Min = 2 and Max = 4 



        //Server send and route receive
        TELL_ROUTE_SERVER_IS_RUNNING,
        START_NEW_GAME_REPLY,//CREATE_CARD, DEAL_CARD, SET_FIRST_TURN, WIN_TOTALLY, RESET_RANKING
        SET_TURN_FLAG,
        SET_WIN_TOTALLY_FLAG, // Optional flag 
        SEND_DEAL_LISTCARDS,


        //Controller
        FIRST_CONNECTING,
        END_GAME,
        SEND_SELECTED_CARDS_FOR_OTHERS,//After checking rules in controller
        CHECK_ROUTE_CONNECTION,
        SET_HOST_PLAYER,
        FIND_ROOM,
        IS_READY,
        SEND_CARDS_IN_MY_TURN,
        I_AM_WINNER
        
    }
}



