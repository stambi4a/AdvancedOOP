namespace Problem_08.Pet_Clinics
{
    using System;

    public class Room
    {
        public Room()
        {
            this.Pet = null;
            this.IsEmpty = true;
        }
        public Pet Pet { get; set; }

        public bool IsEmpty { get; set; }

        public void AddPet(Pet pet)
        {
            this.Pet = pet;
            this.IsEmpty = false;
        }

        public void ReleasePet()
        {
            this.Pet = null;
            this.IsEmpty = true;
        }
        public override string ToString()
        {
            if (this.Pet == null)
            {
                return "Room empty";
            }

            return this.Pet.ToString();
        }
    }
}
