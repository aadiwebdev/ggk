using System;
public class Node
    {
       private int m_data;
       private Node m_leftNode;
       private Node m_rightNode;	

        public int Data
        {
        get
        {
            return m_data;
        }
        set
        {
            m_data=value;
        }	 
        }
        public Node LeftNode
        {
        get
        {
            return m_leftNode;
        }
        set
        {
            m_leftNode=value;
        }	 
        }
        public Node RightNode
        {
        get
        {
            return m_rightNode;
        }
        set
        {
            m_rightNode=value;
        }	 
        }
}

