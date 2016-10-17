namespace Problem_06.Mirror_Image.Data
{
    using System;
    using System.Collections.Generic;

    using Problem_06.Mirror_Image.Interfaces;

    public class WizardTree : IWizardTree
    {
        public WizardTree(IWizardNode root)
        {
            this.Root = root;
            this.Count = 1;
        }
        public IWizardNode Root { get; }

        public int Count { get; }

        public void AddNode()
        {
            throw new System.NotImplementedException();
        }

        public void Traverse(int id)
        {
            throw new System.NotImplementedException();
        }

        public IWizardNode DfsTraverse(int id)
        {
            var current = this.Root;
            var stack = new Stack<IWizardNode>();
            stack.Push(current);
            while (current.Id < id && stack.Count > 0)
            {
                if (current.HasChildren)
                {
                    if (current.LeftChild.Id == id)
                    {
                        return current.LeftChild;
                    }

                    if (current.RightChild.Id == id)
                    {
                        return current.RightChild;
                    }

                    stack.Push(current.RightChild);
                    current = current.LeftChild;
                }
                else
                {
                    current = stack.Pop();
                }
            }

            return current;
        }

        public IWizardNode DfsTraverse(int id, Action<int, string> action)
        {
            var current = this.Root;
            var stack = new Stack<IWizardNode>();
            stack.Push(current);
            while (current.Id < id && stack.Count > 0)
            {
                if (current.HasChildren)
                {
                    if (current.LeftChild.Id == id)
                    {
                        return current.LeftChild;
                    }

                    if (current.RightChild.Id == id)
                    {
                        return current.RightChild;
                    }

                    stack.Push(current.RightChild);
                    current = current.LeftChild;
                }
                else
                {
                    current = stack.Pop();
                }
            }

            return current;
        }
    }
}
