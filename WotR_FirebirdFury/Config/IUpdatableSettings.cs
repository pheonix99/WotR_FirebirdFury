namespace FirebirdFury.Config
{
    public interface IUpdatableSettings
    {
        void OverrideSettings(IUpdatableSettings userSettings);
    }
}