using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;

public class BodySourceView : MonoBehaviour 
{
    public Material BoneMaterial;
    public GameObject BodySourceManager;
    
    private Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>();
    private BodySourceManager _BodyManager;
    
    private Dictionary<Kinect.JointType, Kinect.JointType> _BoneMap = new Dictionary<Kinect.JointType, Kinect.JointType>()
    {
        { Kinect.JointType.FootLeft, Kinect.JointType.AnkleLeft },
        { Kinect.JointType.AnkleLeft, Kinect.JointType.KneeLeft },
        { Kinect.JointType.KneeLeft, Kinect.JointType.HipLeft },
        { Kinect.JointType.HipLeft, Kinect.JointType.SpineBase },
        
        { Kinect.JointType.FootRight, Kinect.JointType.AnkleRight },
        { Kinect.JointType.AnkleRight, Kinect.JointType.KneeRight },
        { Kinect.JointType.KneeRight, Kinect.JointType.HipRight },
        { Kinect.JointType.HipRight, Kinect.JointType.SpineBase },
        
        { Kinect.JointType.HandTipLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.ThumbLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.HandLeft, Kinect.JointType.WristLeft },
        { Kinect.JointType.WristLeft, Kinect.JointType.ElbowLeft },
        { Kinect.JointType.ElbowLeft, Kinect.JointType.ShoulderLeft },
        { Kinect.JointType.ShoulderLeft, Kinect.JointType.SpineShoulder },
        
        { Kinect.JointType.HandTipRight, Kinect.JointType.HandRight },
        { Kinect.JointType.ThumbRight, Kinect.JointType.HandRight },
        { Kinect.JointType.HandRight, Kinect.JointType.WristRight },
        { Kinect.JointType.WristRight, Kinect.JointType.ElbowRight },
        { Kinect.JointType.ElbowRight, Kinect.JointType.ShoulderRight },
        { Kinect.JointType.ShoulderRight, Kinect.JointType.SpineShoulder },
        
        { Kinect.JointType.SpineBase, Kinect.JointType.SpineMid },
        { Kinect.JointType.SpineMid, Kinect.JointType.SpineShoulder },
        { Kinect.JointType.SpineShoulder, Kinect.JointType.Neck },
        { Kinect.JointType.Neck, Kinect.JointType.Head },
    };
    
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

    void Update () 
    {
        if (BodySourceManager == null)
        {
            return;
        }
        
        _BodyManager = BodySourceManager.GetComponent<BodySourceManager>();
        if (_BodyManager == null)
        {
            return;
        }
        
        Kinect.Body[] data = _BodyManager.GetData();
        if (data == null)
        {
            return;
        }
        
        List<ulong> trackedIds = new List<ulong>();
        foreach(var body in data)
        {
            if (body == null)
            {
                continue;
              }
                
            if(body.IsTracked)
            {
                trackedIds.Add (body.TrackingId);
            }
        }
        
        List<ulong> knownIds = new List<ulong>(_Bodies.Keys);
        
        // First delete untracked bodies
        foreach(ulong trackingId in knownIds)
        {
            if(!trackedIds.Contains(trackingId))
            {
                Destroy(_Bodies[trackingId]);
                _Bodies.Remove(trackingId);
            }
        }

        foreach(var body in data)
        {
            if (body == null)
            {
                continue;
            }
            
            if(body.IsTracked)
            {
                if(!_Bodies.ContainsKey(body.TrackingId))
                {
                    _Bodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                }
                
                RefreshBodyObject(body, _Bodies[body.TrackingId]);
            }
        }
    }
    
    private GameObject CreateBodyObject(ulong id)
    {
		//GameObject body = new GameObject("Body:" + id);
        GameObject body = new GameObject("Body");
        
        for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        {
            GameObject jointObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            LineRenderer lr = jointObj.AddComponent<LineRenderer>();
            lr.SetVertexCount(2);
            lr.material = BoneMaterial;
            lr.SetWidth(0.05f, 0.05f);
            
            jointObj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            jointObj.name = jt.ToString();
            jointObj.transform.parent = body.transform;
        }
        
        return body;
    }
    
    private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject)
    {
        for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        {
            Kinect.Joint sourceJoint = body.Joints[jt];
            Kinect.Joint? targetJoint = null;
            
            if(_BoneMap.ContainsKey(jt))
            {
                targetJoint = body.Joints[_BoneMap[jt]];
            }
            
            Transform jointObj = bodyObject.transform.Find(jt.ToString());
            jointObj.localPosition = GetVector3FromJoint(sourceJoint);

			Kinect.Vector4 orientation = body.JointOrientations[jt].Orientation;
			jointObj.rotation = new Quaternion (orientation.X, orientation.Y, orientation.Z, orientation.W);
			//jointObj.localRotation = new Quaternion (orientation.X, orientation.Y, orientation.Z, orientation.W);

            LineRenderer lr = jointObj.GetComponent<LineRenderer>();
            if(targetJoint.HasValue)
            {
                lr.SetPosition(0, jointObj.localPosition);
                lr.SetPosition(1, GetVector3FromJoint(targetJoint.Value));
                lr.SetColors(GetColorForState (sourceJoint.TrackingState), GetColorForState(targetJoint.Value.TrackingState));
            }
            else
            {
                lr.enabled = false;
            }
        }
    }
    


    private static Color GetColorForState(Kinect.TrackingState state)
    {
        switch (state)
        {
        case Kinect.TrackingState.Tracked:
            return Color.green;

        case Kinect.TrackingState.Inferred:
            return Color.red;

        default:
            return Color.black;
        }
    }
    
    private static Vector3 GetVector3FromJoint(Kinect.Joint joint)
    {
		return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
        //return new Vector3(joint.Position.X, joint.Position.Y, joint.Position.Z);
    }
}
