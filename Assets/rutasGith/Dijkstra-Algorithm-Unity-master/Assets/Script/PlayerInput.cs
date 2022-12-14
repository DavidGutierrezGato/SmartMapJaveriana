using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour {

    private Transform node;
    public Transform startNode;
    public Transform endNode;
    private List<Transform> blockPath = new List<Transform>();
    public rutas rutas;
    public GameObject linea;





    /// <summary>
    /// Mouse click.
    /// </summary>


    /// <summary>
    /// Button for Set Starting node.
    /// </summary>
    public void btnStartNode()
    {
        if (node != null)
        {
            Node n = node.GetComponent<Node>();

            // Making sure only walkable node are able to set as start.
            if (n.isWalkable())
            {
                // If this is a new start node, we will just set it to blue.
                if (startNode == null)
                {
                    Renderer rend = node.GetComponent<Renderer>();
                    rend.material.color = Color.blue;
                }
                else
                {
                    // Reverse the color of the previous node
                    Renderer rend = startNode.GetComponent<Renderer>();
                    rend.material.color = Color.white;

                    // Set the new node as blue.
                    rend = node.GetComponent<Renderer>();
                    rend.material.color = Color.blue;
                }

                startNode = node;
                node = null;
            }
        }
    }

    /// <summary>
    /// Button for Set End node.
    /// </summary>
    public void btnEndNode()
    {
        if (node != null)
        {
            Node n = node.GetComponent<Node>();

            // Making sure only walkable node are able to set as end.
            if (n.isWalkable())
            {
                // If this is a new end node, we will just set it to cyan.
                if (endNode == null)
                {
                    Renderer rend = node.GetComponent<Renderer>();
                    rend.material.color = Color.cyan;
                }
                else
                {
                    // Reverse the color of the previous node
                    Renderer rend = endNode.GetComponent<Renderer>();
                    rend.material.color = Color.white;

                    // Set the new node as cyan.
                    rend = node.GetComponent<Renderer>();
                    rend.material.color = Color.cyan;
                }

                endNode = node;
                node = null;
            }
        }
    }

    /// <summary>
    /// Button for find path.
    /// </summary>
    public void btnFindPath()
    {
        double startTime = Time.realtimeSinceStartup;
        // Only find if there are start and end node.
        if (startNode != null && endNode != null)
        {
            // Execute Shortest Path.
            ShortestPath finder = gameObject.GetComponent<ShortestPath>();
            List<Transform> paths = finder.findShortestPath(startNode, endNode);

            // Colour the node red.
            List<GameObject> vecinos = new List<GameObject>();
            foreach (Transform path in paths)
            {
                vecinos.Add(path.gameObject);

            }

            linea.GetComponent<nodo>().vecinos = vecinos;
            linea.GetComponent<nodo>().pintarRuta();
            rutas.empezarRuta(vecinos,true);

            double endTime = (Time.realtimeSinceStartup - startTime);
            print("Compute time: " + endTime);
            Debug.LogError("Compute time: " + endTime);

        }
    }

    public void btnFindPathMejorado(List<GameObject> rutaMejorada)
    {
       

            linea.GetComponent<nodo>().vecinos = rutaMejorada;
            linea.GetComponent<nodo>().pintarRuta();
            rutas.empezarRuta(rutaMejorada,false);

        
    }

    public void btnFindPath(Transform inicio, Transform destino)
    {
        startNode = inicio;
        endNode = destino;
        // Only find if there are start and end node.
        if (startNode != null && endNode != null)
        {
            // Execute Shortest Path.
            ShortestPath finder = gameObject.GetComponent<ShortestPath>();
            List<Transform> paths = finder.findShortestPath(startNode, endNode);

            // Colour the node red.
            List<GameObject> vecinos = new List<GameObject>();
            foreach (Transform path in paths)
            {
                vecinos.Add(path.gameObject);

            }

            linea.GetComponent<nodo>().vecinos = vecinos;
            linea.GetComponent<nodo>().pintarRuta();
            rutas.empezarRuta(vecinos,true);

        }
    }

    /// <summary>
    /// Button for blocking a path.
    /// </summary>
    public void btnBlockPath()
    {
        if (node != null)
        {
            // Render the selected node to black.
            Renderer rend = node.GetComponent<Renderer>();
            rend.material.color = Color.black;

            // Set selected node to not walkable
            Node n = node.GetComponent<Node>();
            n.setWalkable(false);

            // Add the node to the block path list.
            blockPath.Add(node);

            // If the block path is start node, we remove start node.
            if (node == startNode)
            {
                startNode = null;
            }

            // If the block path is end node, we remove end node.
            if (node == endNode)
            {
                endNode = null;
            }

            node = null;
        }

        // For selection grid system.
        UnitSelectionComponent selection = gameObject.GetComponent<UnitSelectionComponent>();
        List<Transform> selected = selection.getSelectedObjects();

        foreach(Transform nd in selected)
        {
            // Render the selected node to black.
            Renderer rend = nd.GetComponent<Renderer>();
            rend.material.color = Color.black;

            // Set selected node to not walkable
            Node n = nd.GetComponent<Node>();
            n.setWalkable(false);

            // Add the node to the block path list.
            blockPath.Add(nd);

            // If the block path is start node, we remove start node.
            if (nd == startNode)
            {
                startNode = null;
            }

            // If the block path is end node, we remove end node.
            if (nd == endNode)
            {
                endNode = null;
            }
        }

        selection.clearSelections();
    }

    /// <summary>
    /// Button to unblock a path.
    /// </summary>
    public void btnUnblockPath()
    {
        if (node != null)
        {
            // Set selected node to white.
            Renderer rend = node.GetComponent<Renderer>();
            rend.material.color = Color.white;

            // Set selected not to walkable.
            Node n = node.GetComponent<Node>();
            n.setWalkable(true);

            // Remove selected node from the block path list.
            blockPath.Remove(node);

            node = null;
        }

        // For selection grid system.
        UnitSelectionComponent selection = gameObject.GetComponent<UnitSelectionComponent>();
        List<Transform> selected = selection.getSelectedObjects();

        foreach (Transform nd in selected)
        {
            // Set selected node to white.
            Renderer rend = nd.GetComponent<Renderer>();
            rend.material.color = Color.white;

            // Set selected not to walkable.
            Node n = nd.GetComponent<Node>();
            n.setWalkable(true);

            // Remove selected node from the block path list.
            blockPath.Remove(nd);
        }

        selection.clearSelections();
    }

    /// <summary>
    /// Clear all the block path.
    /// </summary>
    public void btnClearBlock()
    {   
        // For each blocked path in the list
        foreach(Transform path in blockPath)
        {   
            // Set walkable to true.
            Node n = path.GetComponent<Node>();
            n.setWalkable(true);

            // Set their color to white.
            Renderer rend = path.GetComponent<Renderer>();
            rend.material.color = Color.white;

        }
        // Clear the block path list and 
        blockPath.Clear();
    }

    /// <summary>
    /// Button to restart level.
    /// </summary>
    public void btnRestart()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }

    /// <summary>
    /// Coloured unwalkable path to black.
    /// </summary>
    private void colorBlockPath()
    {
        foreach(Transform block in blockPath)
        {
            Renderer rend = block.GetComponent<Renderer>();
            rend.material.color = Color.black;
        }
    }

    /// <summary>
    /// Refresh Update Nodes Color.
    /// </summary>
    private void updateNodeColor()
    {
        if (startNode != null)
        {
            Renderer rend = startNode.GetComponent<Renderer>();
            rend.material.color = Color.blue;
        }

        if (endNode != null)
        {
            Renderer rend = endNode.GetComponent<Renderer>();
            rend.material.color = Color.cyan;
        }
    }

}
