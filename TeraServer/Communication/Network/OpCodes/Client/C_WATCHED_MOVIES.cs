using TeraServer.Communication.Network.OpCodes.Server;

namespace TeraServer.Communication.Network.OpCodes.Client
{
    public class C_WATCHED_MOVIES : AClientPacket
    {
        public override void Read()
        {
            
        }

        public override void Process()
        {
            S_WATCHED_MOVIES sWatchedMovies = new S_WATCHED_MOVIES();
            sWatchedMovies.Send(this.Connection);
        }
    }
}