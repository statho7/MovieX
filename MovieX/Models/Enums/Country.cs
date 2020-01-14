using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieX.Models.Enums
{
    public enum Country
    {
        Albania,
        Andorra,
        Armenia,
        Austria,
        Azerbaijan,
        Belarus,
        Belgium,
        [Display(Name = "Bosnia & Herzegovina")]
        BosniaHerzegovina,
        Bulgaria,
        Croatia,
        Cyprus,
        [Display(Name = "Czech Republic")]
        CzechRepublic,
        Denmark,
        Estonia,
        Finland,
        France,
        FYROM,
        Georgia,
        Germany,
        Greece,
        Hungary,
        Iceland,
        Ireland,
        Italy,
        Kazakhstan,
        Kosovo,
        Latvia,
        Liechtenstein,
        Lithuania,
        Luxembourg,
        Malta,
        Moldova,
        Monaco,
        Montenegro,
        Netherlands,
        Norway,
        Poland,
        Portugal,
        Romania,
        Russia,
        [Display(Name = "San Marino")]
        SanMarino,
        Serbia,
        Slovakia,
        Slovenia,
        Spain,
        Sweden,
        Switzerland,
        Turkey,
        Ukraine,
        [Display(Name = "United Kingdom(UK)")]
        UnitedKingdom,
        [Display(Name = "Vatican City")]
        VaticanCity
    }
}