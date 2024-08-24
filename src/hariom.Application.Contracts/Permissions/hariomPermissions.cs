namespace Hariom.Permissions;

public static class HariomPermissions
{
    public const string GroupName = "Hariom";

    public static class Diseases
    {
        public const string Default = GroupName + ".Diseases";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Medicines
    {
        public const string Default = GroupName + ".Medicines";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Mantras
    {
        public const string Default = GroupName + ".Mantras";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class YogTherapies
    {
        public const string Default = GroupName + ".YogTherapies";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Treatments
    {
        public const string Default = GroupName + ".Treatments";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
