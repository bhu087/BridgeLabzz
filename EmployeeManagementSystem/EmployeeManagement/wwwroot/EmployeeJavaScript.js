function activeLogin() {
	$(document).ready(function () {
		$("#LoginDiv").show();
	});
	deActiveParagraph();
}
function deActiveLogin() {
	$(document).ready(function () {
		$("#LoginDiv").hide();
	});
}
function activeEmployeeManagement() {
	$(document).ready(function () {
		$("#EmployeeManagement").show();
	});
	deActiveParagraph();
}
function deActiveEmployeeManagement() {
	$(document).ready(function () {
		$("#EmployeeManagement").hide();
	});
}
function activeParagraph() {
	$(document).ready(function () {
		$("#paragraph").show();
	});
	deActiveEmployeeManagement();
	deActiveLogin();
}
function deActiveParagraph() {
	$(document).ready(function () {
		$("#paragraph").hide();
	});
}
function LoginAction() {
	$("#Login").click(function () {
		var formData = new FormData;
		formData.append("name", $("#LoginName").val());
		formData.append("userId", $("#LoginPassword").val());
		formData.append("mobile", $("#LoginMobile").val());
		$.ajax({
			url: "api/add",
			type: 'POST',
			cache: false,
			contentType: false,
			processData: false,
			data: formData,
			success: function (response) {
				window.location.href = 'https://localhost:44378/Login.html'
				alert("Added!");
			}
		});
	});
}