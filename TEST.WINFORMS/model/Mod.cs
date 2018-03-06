using System;

namespace TEST.WINFORMS.model
{
    public class Mod : IMod
    {
        public long id { get; set; }

        public DateTime birthday { get; set; }

        public float inn { get; set; }

        public string lastname { get; set; }

        public string loc_dom { get; set; }

        public float loc_index { get; set; }

        public string loc_korp { get; set; }

        public string loc_kvart { get; set; }

        public string loc_nas_punkt { get; set; }

        public string loc_region { get; set; }

        public string loc_ulica { get; set; }

        public string name { get; set; }

        public DateTime pass_date { get; set; }

        public string pass_loc { get; set; }

        public string pass_number { get; set; }

        public string pass_seria { get; set; }

        public string reg_dom { get; set; }

        public float reg_index { get; set; }

        public string reg_korp { get; set; }

        public string reg_kvart { get; set; }

        public string reg_nas_punkt { get; set; }

        public string reg_region { get; set; }

        public string reg_ulica { get; set; }

        public bool sex { get; set; }

        public string surname { get; set; }

        public jobs jobs { get; set; }

        public Family fam { get; set; }

    }
}
