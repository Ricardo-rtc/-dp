import {Component} from 'react';
import {Map, InfoWindow, Marker, GoogleApiWrapper} from 'google-maps-react';
 
export class MapContainer extends Component {
    constructor(props) {
        super(props)
        this.state= {
            selectedPlace: "",
            stores: [
              { latitude: -23.536381, longitude: -46.6461279, local: "Clínica Possarle" }]
          
        }
    }

    displayMarkers = () => {
      return this.state.stores.map((store, index) => {
        return <Marker key={index} id={index} position={{
          lat: store.latitude,
          lng: store.longitude
        }}
        />
      })
    }
  render() {
    return (
      
      <Map google={this.props.google} zoom={18}  initialCenter={{ lat: -23.536381, lng: -46.6461279 }}>

 {this.displayMarkers()}
 
        
 
        <InfoWindow onClose={this.onInfoWindowClose}>
            <div>
              <h1>{this.state.selectedPlace.name}</h1>
            </div>
        </InfoWindow>
      </Map>
    );
  }
}
 
export default GoogleApiWrapper({
  apiKey: ('AIzaSyDlpQjXpE3I84Q-XF-Rm7dIZMcqvz6dsSs')
})(MapContainer)