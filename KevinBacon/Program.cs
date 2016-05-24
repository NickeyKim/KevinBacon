using System;
using System.Collections.Generic;

namespace KevinBacon
{
	/*Dijkstra's algorithm ( if only, weight or length given)
	 * let's try the depth first search 
	 * 
	 */
	public class ActorGraphNode
	{
		private String name;
		private ISet<ActorGraphNode> linkedActors;
		private int baconNumber = -1;

		public int getBaconNumber(){
			return baconNumber;
		}
		public void setBaconNumber(){
			baconNumber = 0;
			Queue<ActorGraphNode> queue = new Queue<ActorGraphNode> ();
			queue.Enqueue (this);
			ActorGraphNode current;


			while ( queue.Count >= 1)
			{
				current = queue.Dequeue ();
				Console.WriteLine (current.name);
				foreach(ActorGraphNode n  in current.linkedActors){
					if ( -1 == n.baconNumber) {
						n.baconNumber = current.baconNumber + 1;
						queue.Enqueue (n);
					}

				}
				Console.WriteLine ("BaconNumber is :"+ current.getBaconNumber());
			}
		}
		public ActorGraphNode (String name)
		{
			this.name = name;
			linkedActors = new HashSet<ActorGraphNode> ();
		}
		public void linkCostar (ActorGraphNode costar){

			linkedActors.Add (costar);
			costar.linkedActors.Add (this);
		}
			
		public static void Main (string[] args)
		{
			ActorGraphNode Kevin = new ActorGraphNode ("Kevin");
			ActorGraphNode Rock = new ActorGraphNode ("Rock");
			ActorGraphNode A = new ActorGraphNode ("A");
			ActorGraphNode B = new ActorGraphNode ("B");
			ActorGraphNode C = new ActorGraphNode ("C");

			Kevin.linkCostar(Rock);
			Rock.linkCostar (A);
			B.linkCostar (C);
			Kevin.setBaconNumber ();

			Console.WriteLine ("A's Bacon Number is "+A.getBaconNumber ());
			//Console.WriteLine (Kevin.name + "->" );
		}
	}
}