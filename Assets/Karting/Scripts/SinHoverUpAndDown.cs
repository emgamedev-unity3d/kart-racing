using UnityEngine;

public class SinHoverUpAndDown : MonoBehaviour
{
    [SerializeField]
    private float m_hoverSpeed = 1.0f;

    [SerializeField]
    private float m_hoverHeight = 0.2f;

    [SerializeField]
    private bool m_ShouldRandomizeStartValue;

    private float m_randomizedStartValue = 0f;

    private float m_startYposition = 0f;

    private Vector3 m_updatedPosition;

    private void Start()
    {
        m_startYposition = transform.position.y;

        if(m_ShouldRandomizeStartValue)
        {
            m_randomizedStartValue = Random.Range(-1f, 1f);
        }
    }

    private void Update()
    {
        float currentSinValue = Mathf.Sin(m_randomizedStartValue + Time.time);

        m_updatedPosition.x = transform.position.x;
        m_updatedPosition.y = m_startYposition +
            (m_hoverHeight * currentSinValue * m_hoverSpeed);
        m_updatedPosition.z = transform.position.z;

        transform.position = m_updatedPosition;
    }
}
