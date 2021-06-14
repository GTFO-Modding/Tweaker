using System;

namespace Dex.Tweaker.DataTransfer
{
    class ExpeditionButton
    {
        public ExpeditionButton(string label, float x, float y, float z, float scale, string decrypt = null, bool heat = false, string status = null)
        {
            Decrypt = decrypt;
            Label = label;
            Heat = heat;
            Status = status;
            Scale = scale;
            Position = new Vector3(x, y, z);
        }
        public string Decrypt { get; set; }
        public string Label { get; set; }
        public bool Heat { get; set; }
        public string Status { get; set; }
        public float Scale { get; set; }
        public Vector3 Position { get; set; }
    }
}
