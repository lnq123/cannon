
var explosionPrefab : Transform;

function OnCollisionEnter(collision : Collision) {

    var contact = collision.contacts[0];
    var rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
    var pos = contact.point;
    Instantiate(explosionPrefab, pos, rot);
    
    if (collision.gameObject.CompareTag("Target")){
   		collision.gameObject.SetActive (false);
   	}
    Destroy (gameObject, 0);
}
