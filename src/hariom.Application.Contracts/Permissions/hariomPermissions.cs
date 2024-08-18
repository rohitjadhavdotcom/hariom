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
}
