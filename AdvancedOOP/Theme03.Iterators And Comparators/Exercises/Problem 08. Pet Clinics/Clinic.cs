namespace Problem_08.Pet_Clinics
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Clinic
    {
        private AddEnumerator<Room> addEnumerator;

        private ReleaseEnumerator<Room> releaseEnumerator;

        public Clinic(string name, int capacity)
        {
            this.Name = name;
            this.BuildClinic(capacity);
            this.addEnumerator = new AddEnumerator<Room>(this.Rooms);
            this.releaseEnumerator = new ReleaseEnumerator<Room>(this.Rooms);
        }

        public string Name { get; }
        public Room[] Rooms { get; private set; }

        private void BuildClinic(int capacity)
        {
            if (capacity % 2 == 0)
            {
                throw new ArgumentException();
            }

            this.Rooms = new Room[capacity];
            for (var i = 0; i < capacity; i++)
            {
                this.Rooms[i] = new Room();
            }
        }

        public bool AddPet(Pet pet)
        {
            this.addEnumerator = new AddEnumerator<Room>(this.Rooms);
            Room roomToPopulate = this.addEnumerator.FirstOrDefault(room => room.IsEmpty);

            if (roomToPopulate == null)
            {
                return false;
            }

            roomToPopulate.AddPet(pet);
            return true;
        }

        public bool Release()
        {
            this.releaseEnumerator = new ReleaseEnumerator<Room>(this.Rooms);
            var fullRoom = this.releaseEnumerator.FirstOrDefault(room => !room.IsEmpty);
            if (fullRoom == null)
            {
                return false;
            }

            fullRoom.ReleasePet();

            return true;
        }

        public bool HasEmptyRooms()
        {
            return this.Rooms.Any(room => room.IsEmpty);
        }

        public void Print(int roomIndex)
        {
            Console.WriteLine(this.Rooms[roomIndex - 1]);
        }

        public void Print()
        {
            Console.WriteLine(this);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Clinic;
            return this.Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.Length << 16 + this.Name.ToCharArray().Sum(letter => (int)letter);
        }

        public override string ToString()
        {
            return string.Join<Room>(Environment.NewLine, this.Rooms);
        }
    }
}
