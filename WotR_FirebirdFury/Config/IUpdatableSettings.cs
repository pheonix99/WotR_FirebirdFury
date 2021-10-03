namespace WotR_FirebirdFury.Config
{
    public interface IUpdatableSettings
    {
        void OverrideSettings(IUpdatableSettings userSettings);
    }
}