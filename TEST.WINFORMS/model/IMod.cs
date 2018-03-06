using System;

namespace TEST.WINFORMS.model
{
    public interface IMod
    {
        string surname { get; set; }
        string name { get; set; }
        string lastname { get; set; }
        bool sex { get; set; }
        DateTime birthday { get; set; }
        string pass_seria { get; set; }
        string pass_number { get; set; }
        string pass_loc { get; set; }
        DateTime pass_date { get; set; }
        float inn { get; set; }
        float reg_index { get; set; }
        string reg_region { get; set; }
        string reg_nas_punkt { get; set; }
        string reg_ulica { get; set; }
        string reg_dom { get; set; }
        string reg_korp { get; set; }
        string reg_kvart { get; set; }
        float loc_index { get; set; }
        string loc_region { get; set; }
        string loc_nas_punkt { get; set; }
        string loc_ulica { get; set; }
        string loc_dom { get; set; }
        string loc_korp { get; set; }
        string loc_kvart { get; set; }
    }
}
