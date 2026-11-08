/****************************
 * EnumerationMember.java
 ****************************/
Package ConceptMeta.entity;

import java.io.Serializable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import org.hibernate.annotations.Type;

/**
 * An item within a constrained vocabulary
 */
@Entity
@Table(name = "EnumerationMember", schema = "dbo")
public class EnumerationMember {

    // Instance Variables region

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "EnumerationMemberId")
    private Integer enumerationMemberId;

    @Column(name = "ConceptModelId")
    private Integer conceptModelId;

    @Column(name = "ModelName")
    private String modelName;

    @Column(name = "DataTypeId")
    private Integer dataTypeId;

    @Column(name = "DataTypeName")
    private String dataTypeName;

    @Column(name = "EnumerationId")
    private Integer enumerationId;

    @Column(name = "EnumerationName")
    private String enumerationName;

    @Column(name = "EnumeratedValue")
    private String enumeratedValue;

    @Column(name = "EnumeratedValueDescription")
    private String enumeratedValueDescription;

    @ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name = "EnumerationId")
    private Enumeration enumeration;

    // end of region

    // Instance Properties region

    /**
     * The ID of the EnumerationMember
     */
    public Integer getEnumerationMemberId {
        return this.enumerationMemberId;
    }
    public void setEnumerationMemberId {
        enumerationMemberId = value;
    }

    /**
     * The ID of the Enumeration
     */
    public Integer getEnumerationId {
        return this.enumerationId;
    }
    public void setEnumerationId {
        enumerationId = value;
    }

    public String getEnumeratedValue {
        return this.enumeratedValue;
    }
    public void setEnumeratedValue {
        enumeratedValue = value;
    }

    public String getEnumeratedValueDescription {
        return this.enumeratedValueDescription;
    }
    public void setEnumeratedValueDescription {
        enumeratedValueDescription = value;
    }

    /**
     * the associated Enumeration object
     * that is referenced using the EnumerationId property
     */
    public Enumeration getEnumeration {
        return this.enumeration;
    }
    public void setEnumeration {
        enumeration = value;
    }

    // end of region
}
