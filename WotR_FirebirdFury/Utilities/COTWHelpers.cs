using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WotR_FirebirdFury.Utilities
{
    public class COTWHelpers
    {
        static public PrerequisiteParametrizedFeature createPrerequisiteParametrizedFeatureWeapon(BlueprintFeatureReference feature, WeaponCategory category, bool any = false)
        {
            var p = Helpers.Create<PrerequisiteParametrizedFeature>();
            p.m_Feature = feature;
            p.ParameterType = FeatureParameterType.WeaponCategory;
            
            p.WeaponCategory = category;
            p.Group = any ? Prerequisite.GroupType.Any : Prerequisite.GroupType.All;
            return p;
        }
    }
}
