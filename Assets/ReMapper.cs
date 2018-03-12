using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReMapper : MonoBehaviour {

	private GameObject kinectSpineBase;
	private GameObject kinectSpineMid;
	private GameObject kinectNeck;
	private GameObject kinectHead;
	private GameObject kinectShoulderLeft;
	private GameObject kinectElbowLeft;
	private GameObject kinectWristLeft;
	private GameObject kinectHandLeft;
	private GameObject kinectHipLeft;
	private GameObject kinectKneeLeft;
	private GameObject kinectAnkleLeft;
	private GameObject kinectFootLeft;
	private GameObject kinectShoulderRight;
	private GameObject kinectElbowRight;
	private GameObject kinectWristRight;
	private GameObject kinectHandRight;
	private GameObject kinectHipRight;
	private GameObject kinectKneeRight;
	private GameObject kinectAnkleRight;
	private GameObject kinectFootRight;
	private GameObject kinectHandTipLeft;
	private GameObject kinectThumbLeft;
	private GameObject kinectHandTipRight;
	private GameObject kinectThumbRight;
		   
	public GameObject AvatarSpineBase;
	public GameObject AvatarSpineMid;
	public GameObject AvatarNeck;
	public GameObject AvatarHead;
	public GameObject AvatarShoulderLeft;
	public GameObject AvatarElbowLeft;
	public GameObject AvatarWristLeft;
	public GameObject AvatarHandLeft;
	public GameObject AvatarHipLeft;
	public GameObject AvatarKneeLeft;
	public GameObject AvatarAnkleLeft;
	public GameObject AvatarFootLeft;
	public GameObject AvatarShoulderRight;
	public GameObject AvatarElbowRight;
	public GameObject AvatarWristRight;
	public GameObject AvatarHandRight;
	public GameObject AvatarHipRight;
	public GameObject AvatarKneeRight;
	public GameObject AvatarAnkleRight;
	public GameObject AvatarFootRight;
	public GameObject AvatarHandTipLeft;
	public GameObject AvatarThumbLeft;
	public GameObject AvatarHandTipRight;
	public GameObject AvatarThumbRight;

	private string stringSpineBase = "SpineBase";
	private string stringSpineMid = "SpineMid";
	private string stringNeck = "Neck";
	private string stringHead = "Head";
	private string stringShoulderLeft = "ShoulderLeft";
	private string stringElbowLeft = "ElbowLeft";
	private string stringWristLeft = "WristLeft";
	private string stringHandLeft = "HandLeft";
	private string stringHipLeft = "HipLeft";
	private string stringKneeLeft = "KneeLeft";
	private string stringAnkleLeft = "AnkleLeft";
	private string stringFootLeft = "FootLeft";
	private string stringShoulderRight = "ShoulderRight";
	private string stringElbowRight = "ElbowRight";
	private string stringWristRight = "WristRight";
	private string stringHandRight = "HandRight";
	private string stringHipRight = "HipRight";
	private string stringKneeRight = "KneeRight";
	private string stringAnkleRight = "AnkleRight";
	private string stringFootRight = "FootRight";
	private string stringHandTipLeft = "HandTipLeft";
	private string stringThumbLeft = "ThumbLeft";
	private string stringHandTipRight = "HandTipRight";
	private string stringThumbRight = "ThumbRight";

	private Vector3 avatarPosition = new Vector3(1,1,1);

	private GameObject[] kinectJointArray = new GameObject[24];
	private GameObject[] avatarJointArray = new GameObject[24];

	// Use this for initialization
	void Start () {
		//avatarPosition = transform.position;
		avatarJointArray[0] = AvatarSpineBase;
		avatarJointArray[1] = AvatarSpineMid;
		avatarJointArray[2] = AvatarNeck;
		avatarJointArray[3] = AvatarHead;
		avatarJointArray[4] = AvatarShoulderLeft;
		avatarJointArray[5] = AvatarElbowLeft;
		avatarJointArray[6] = AvatarWristLeft;
		avatarJointArray[7] = AvatarHandLeft;
		avatarJointArray[8] = AvatarHipLeft;
		avatarJointArray[9] = AvatarKneeLeft;
		avatarJointArray[10] = AvatarAnkleLeft;
		avatarJointArray[11] = AvatarFootLeft;
		avatarJointArray[12] = AvatarShoulderRight;
		avatarJointArray[13] = AvatarElbowRight;
		avatarJointArray[14] = AvatarWristRight;
		avatarJointArray[15] = AvatarHandRight;
		avatarJointArray[16] = AvatarHipRight;
		avatarJointArray[17] = AvatarKneeRight;
		avatarJointArray[18] = AvatarAnkleRight;
		avatarJointArray[19] = AvatarFootRight;
		avatarJointArray[20] = AvatarHandTipLeft;
		avatarJointArray[21] = AvatarThumbLeft;
		avatarJointArray[22] = AvatarHandTipRight;
		avatarJointArray[23] = AvatarThumbRight;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject body = GameObject.Find ("Body");
		if(body)
		{
			GameObject objectSpineBase = GameObject.Find (stringSpineBase);
			GameObject objectSpineMid = GameObject.Find (stringSpineMid);
			GameObject objectNeck = GameObject.Find (stringNeck);
			GameObject objectHead = GameObject.Find (stringHead);
			GameObject objectShoulderLeft = GameObject.Find (stringShoulderLeft);
			GameObject objectElbowLeft = GameObject.Find (stringElbowLeft);
			GameObject objectWristLeft = GameObject.Find (stringWristLeft);
			GameObject objectHandLeft = GameObject.Find (stringHandLeft);
			GameObject objectHipLeft = GameObject.Find (stringHipLeft);
			GameObject objectKneeLeft = GameObject.Find (stringKneeLeft);
			GameObject objectAnkleLeft = GameObject.Find (stringAnkleLeft);
			GameObject objectFootLeft = GameObject.Find (stringFootLeft);
			GameObject objectShoulderRight = GameObject.Find (stringShoulderRight);
			GameObject objectElbowRight = GameObject.Find (stringElbowRight);
			GameObject objectWristRight = GameObject.Find (stringWristRight);
			GameObject objectHandRight = GameObject.Find (stringHandRight);
			GameObject objectHipRight = GameObject.Find (stringHipRight);
			GameObject objectKneeRight = GameObject.Find (stringKneeRight);
			GameObject objectAnkleRight = GameObject.Find (stringAnkleRight);
			GameObject objectFootRight = GameObject.Find (stringFootRight);
			GameObject objectHandTipLeft = GameObject.Find (stringHandTipLeft);
			GameObject objectThumbLeft = GameObject.Find (stringThumbLeft);
			GameObject objectHandTipRight = GameObject.Find (stringHandTipRight);
			GameObject objectThumbRight = GameObject.Find (stringThumbRight);

			kinectJointArray[0] = objectSpineBase;
			kinectJointArray[1] = objectSpineMid;
			kinectJointArray[2] = objectNeck;
			kinectJointArray[3] = objectHead;
			kinectJointArray[4] = objectShoulderLeft;
			kinectJointArray[5] = objectElbowLeft;
			kinectJointArray[6] = objectWristLeft;
			kinectJointArray[7] = objectHandLeft;
			kinectJointArray[8] = objectHipLeft;
			kinectJointArray[9] = objectKneeLeft;
			kinectJointArray[10] = objectAnkleLeft;
			kinectJointArray[11] = objectFootLeft;
			kinectJointArray[12] = objectShoulderRight;
			kinectJointArray[13] = objectElbowRight;
			kinectJointArray[14] = objectWristRight;
			kinectJointArray[15] = objectHandRight;
			kinectJointArray[16] = objectHipRight;
			kinectJointArray[17] = objectKneeRight;
			kinectJointArray[18] = objectAnkleRight;
			kinectJointArray[19] = objectFootRight;
			kinectJointArray[20] = objectHandTipLeft;
			kinectJointArray[21] = objectThumbLeft;
			kinectJointArray[22] = objectHandTipRight;
			kinectJointArray[23] = objectThumbRight;

			int i;
			for(i=0; i<24; i++)
			{
				if(kinectJointArray[i] && avatarJointArray[i])
				{
					//avatarJointArray [i].transform.position = kinectJointArray [i].transform.position / 10 + avatarPosition;
					avatarJointArray [i].transform.rotation = kinectJointArray [i].transform.rotation;
					//if (i == 0) 
					//{
					//}
					//else 
					//{
					//	avatarJointArray [i].transform.rotation = kinectJointArray [i].transform.rotation;
					//}
				}
			}


		}
	}
}
