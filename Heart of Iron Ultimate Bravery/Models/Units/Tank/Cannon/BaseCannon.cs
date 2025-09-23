using System.Collections.Generic;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Cannon;

public abstract class BaseCannon
{
    // Abstract methods that each mod implementation must provide
    public abstract void InitializeModSpecificProperties();
    public abstract void InitializeModSpecificProperties(List<VanillaCannon.CannonSize> allowedCannonSize);
    public abstract string GetModIdentifier();
}