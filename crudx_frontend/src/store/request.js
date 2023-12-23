import Axios from "axios";

const request = (context, path, method, body, access=true) => {
    return Axios({
        url: import.meta.env.VITE_API_URL+path,
        method: method,
        data: body || {},
    }).then(data => {
        return data
    }).catch(err => {
        // if(err.response.status === 401 && access || err.response.status === 422 && access)
        //     return REFRESH({path, method, body})

        // if(err.response.status === 404)
        //     router.push({path: '/404', query: {msg: err.response.data.obj.msg}})
        return err.response.data
    })
}

export default request